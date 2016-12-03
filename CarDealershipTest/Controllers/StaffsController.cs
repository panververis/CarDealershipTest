using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CarDealershipTest.Models;
using System.Web.Script.Serialization;

namespace CarDealershipTest.Controllers
{
    public class StaffsController : ApiController
    {
        private CarDealershipTestContext _db = new CarDealershipTestContext();

        public class Filter
        {
            public string DateFrom { get; set; }
            public string DateTo { get; set; }
            public string Region { get; set; }
            public string Area { get; set; }
            public string Staff { get; set; }
        }

        // GET: api/Staffs
        public IEnumerable<Staff> GetStaffs(string filter)
        {

            //fetching the necessary data
            var staffSalesInfo = (
                from staffTable in _db.Staffs
                join salesTable in _db.Sales on staffTable.ID equals salesTable.StaffID
                join dealersTable in _db.Dealers on staffTable.DealerID equals dealersTable.ID
                join regionsTable in _db.Regions on dealersTable.RegionID equals regionsTable.ID
                join areasTable in _db.Areas on regionsTable.AreaID equals areasTable.ID
                group staffTable by new {
                                StaffID = staffTable.ID,
                                StaffFirstName = staffTable.FirstName,
                                StaffLastName = staffTable.LastName,
                                SaleDate = salesTable.SaleDate,
                                RegionID = regionsTable.ID,
                                RegionName = regionsTable.Name,
                                AreasID = areasTable.ID,
                                AreaName = areasTable.Name
                }
                into staffSales
                select new
                {
                    StaffID = staffSales.Key.StaffID,
                    StaffFirstName = staffSales.Key.StaffFirstName,
                    StaffLastName = staffSales.Key.StaffLastName,
                    SaleDate = staffSales.Key.SaleDate,
                    RegionName = staffSales.Key.RegionName,
                    AreaName = staffSales.Key.AreaName,
                    NoOfSales = staffSales.Count()
                }
            );

            Filter filterObject = null;
            if (!String.IsNullOrEmpty(filter))
            {
                filterObject = new JavaScriptSerializer().Deserialize<Filter>(filter);
            }

            //applying the Filter Values to the Linq expression
            if (filterObject != null)
            {
                if (!String.IsNullOrEmpty(filterObject.DateFrom))
                {
                    DateTime dateFrom = Convert.ToDateTime(filterObject.DateFrom);
                    if (dateFrom != DateTime.MinValue)
                    {
                        staffSalesInfo = staffSalesInfo.Where(x => x.SaleDate >= dateFrom);
                    }
                }
                if (!String.IsNullOrEmpty(filterObject.DateTo))
                {
                    DateTime dateTo = Convert.ToDateTime(filterObject.DateTo);
                    if (dateTo != DateTime.MinValue)
                    {
                        staffSalesInfo = staffSalesInfo.Where(x => x.SaleDate <= dateTo);
                    }
                }
                if (!String.IsNullOrEmpty(filterObject.Region))
                {
                    staffSalesInfo = staffSalesInfo.Where(x => x.RegionName.Contains(filterObject.Region));
                }
                if (!String.IsNullOrEmpty(filterObject.Area))
                {
                    staffSalesInfo = staffSalesInfo.Where(x => x.AreaName.Contains(filterObject.Area));
                }
                if (!String.IsNullOrEmpty(filterObject.Staff))
                {
                    staffSalesInfo = staffSalesInfo.Where(x => x.StaffFirstName.Contains(filterObject.Staff) || x.StaffLastName.Contains(filterObject.Staff));
                }
            }

            //order the result by the appropriate fields
            staffSalesInfo = staffSalesInfo.OrderBy(x => x.StaffLastName).ThenBy(y => y.SaleDate);

            //initializing the to-be-returned List of Staff
            List<Staff> staffSalesList = new List<Staff>();

            //populating the List of Staff(StaffSales information)
            staffSalesInfo.ToList().ForEach(x => staffSalesList.Add(new Staff()
            {
                FullName = $"{x.StaffLastName} {x.StaffFirstName}",
                NumberOfSales = x.NoOfSales
            }));

            return staffSalesList;
        }

        // GET: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> GetStaff(int id)
        {
            Staff staff = await _db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStaff(int id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.ID)
            {
                return BadRequest();
            }

            _db.Entry(staff).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Staffs.Add(staff);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = staff.ID }, staff);
        }

        // DELETE: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> DeleteStaff(int id)
        {
            Staff staff = await _db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _db.Staffs.Remove(staff);
            await _db.SaveChangesAsync();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffExists(int id)
        {
            return _db.Staffs.Count(e => e.ID == id) > 0;
        }
    }
}