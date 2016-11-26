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
        private CarDealershipTestContext db = new CarDealershipTestContext();

        // GET: api/Sales
        public IEnumerable<Sale> GetSales()
        {
            //fetching the necessary data
            var salesInfos = (
                            from salesTable in db.Sales
                            join dealersTable in db.Dealers on salesTable.DealerID equals dealersTable.ID
                            join staffTable in db.Staffs on salesTable.StaffID equals staffTable.ID
                            join vehiclesTable in db.Vehicles on salesTable.VehicleID equals vehiclesTable.ID
                            select new
                            {
                                DealerName = dealersTable.Name,
                                StaffFirstName = staffTable.FirstName,
                                StaffLastName = staffTable.LastName,
                                VehicleName = vehiclesTable.Name,
                                SaleInfoDate = salesTable.SaleDate,
                                SaleInfoValue = salesTable.SaleValue
                            }
                        ).AsEnumerable();

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
            Sale sale = await db.Sales.FindAsync(id);
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

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            db.Sales.Add(sale);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sale.ID }, sale);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> DeleteSale(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            await db.SaveChangesAsync();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.ID == id) > 0;
        }
    }
}