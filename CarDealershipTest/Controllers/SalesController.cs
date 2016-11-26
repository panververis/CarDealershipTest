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
using WebGrease.Css.Extensions;

namespace CarDealershipTest.Controllers
{
    public class SalesController : ApiController
    {
        private readonly CarDealershipTestContext _db = new CarDealershipTestContext();

        // GET: api/Sales
        public IEnumerable<Sale> GetSales()
        {
            //fetching the necessary data
            var salesInfos = (
                            from salesTable in _db.Sales
                            join dealersTable in _db.Dealers on salesTable.DealerID equals dealersTable.ID
                            join staffTable in _db.Staffs on salesTable.StaffID equals staffTable.ID
                            join vehiclesTable in _db.Vehicles on salesTable.VehicleID equals vehiclesTable.ID
                            select new
                            {
                                DealerName = dealersTable.Name,
                                StaffFirstName = staffTable.FirstName,
                                StaffLastName = staffTable.LastName,
                                VehicleName = vehiclesTable.Name,
                                SaleInfoDate = salesTable.SaleDate,
                                SaleInfoValue = salesTable.SaleValue
                            }
                        ).OrderBy(x => x.DealerName).ThenBy(y => y.SaleInfoDate).AsEnumerable();

            //initializing the to-be-returned List of Sales
            List<Sale> sales = new List<Sale>();

            //populating the List of Sales
            salesInfos.ForEach(x => sales.Add(new Sale()
            {
                DealerName = x.DealerName,
                StaffName = $"{x.StaffLastName} {x.StaffFirstName}",
                VehicleName = x.VehicleName,
                FormattedSaleDate = x.SaleInfoDate.ToShortDateString(),
                SaleValue = x.SaleInfoValue
            }));

            return sales;
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> GetSale(int id)
        {
            Sale sale = await _db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSale(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.ID)
            {
                return BadRequest();
            }

            _db.Entry(sale).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sale.ID }, sale);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> DeleteSale(int id)
        {
            Sale sale = await _db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _db.Sales.Remove(sale);
            await _db.SaveChangesAsync();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return _db.Sales.Count(e => e.ID == id) > 0;
        }
    }
}