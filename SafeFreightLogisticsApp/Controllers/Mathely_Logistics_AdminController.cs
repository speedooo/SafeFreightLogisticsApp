using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SafeFreightLogisticsApp.Models;

namespace SafeFreightLogisticsApp.Controllers
{
    [Authorize]
    public class Mathely_Logistics_AdminController : Controller
    {
        private SafeFreightDB db = new SafeFreightDB();

        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: Countries
        public async Task<ActionResult> CountriesIndex()
        {
            try
            {
                return View(await db.Countries.OrderBy(x => x.Name).ToListAsync());
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: Countries/Details/5
        public async Task<ActionResult> CountriesDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                Country country = await db.Countries.FindAsync(id);

                if (country == null)
                {
                    return View("ErrorNotFound");
                }

                return View(country);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: Countries/Create
        public ActionResult CountriesCreate()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CountriesCreate([Bind(Include = "CountryId,Name")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Countries.Add(country);
                    await db.SaveChangesAsync();
                    return RedirectToAction("CountriesIndex");
                }

                return View(country);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: Countries/Edit/5
        public async Task<ActionResult> CountriesEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                Country country = await db.Countries.FindAsync(id);

                if (country == null)
                {
                    return View("ErrorNotFound");
                }

                return View(country);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CountriesEdit([Bind(Include = "CountryId,Name")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(country).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("CountriesIndex");
                }
                return View(country);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: Countries/Delete/5
        public async Task<ActionResult> CountriesDelete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                Country country = await db.Countries.FindAsync(id);

                if (country == null)
                {
                    return View("ErrorNotFound");
                }

                return View(country);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("CountriesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CountriesDeleteConfirmed(int id)
        {
            try
            {
                Country country = await db.Countries.FindAsync(id);
                db.Countries.Remove(country);
                await db.SaveChangesAsync();
                return RedirectToAction("CountriesIndex");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: HalfHourlyTimes
        public async Task<ActionResult> HalfHourlyTimesIndex()
        {
            try
            {
                return View(await db.HalfHourlyTimes.ToListAsync());
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: HalfHourlyTimes/Details/5
        public async Task<ActionResult> HalfHourlyTimesDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                HalfHourlyTime halfHourlyTime = await db.HalfHourlyTimes.FindAsync(id);

                if (halfHourlyTime == null)
                {
                    return View("ErrorNotFound");
                }

                return View(halfHourlyTime);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: HalfHourlyTimes/Create
        public ActionResult HalfHourlyTimesCreate()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: HalfHourlyTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> HalfHourlyTimesCreate([Bind(Include = "HalfHourlyTimeId,TimePeriod")] HalfHourlyTime halfHourlyTime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.HalfHourlyTimes.Add(halfHourlyTime);
                    await db.SaveChangesAsync();
                    return RedirectToAction("HalfHourlyTimesIndex");
                }

                return View(halfHourlyTime);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: HalfHourlyTimes/Edit/5
        public async Task<ActionResult> HalfHourlyTimesEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                HalfHourlyTime halfHourlyTime = await db.HalfHourlyTimes.FindAsync(id);

                if (halfHourlyTime == null)
                {
                    return View("ErrorNotFound");
                }

                return View(halfHourlyTime);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: HalfHourlyTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> HalfHourlyTimesEdit([Bind(Include = "HalfHourlyTimeId,TimePeriod")] HalfHourlyTime halfHourlyTime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(halfHourlyTime).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("HalfHourlyTimesIndex");
                }
                return View(halfHourlyTime);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: HalfHourlyTimes/Delete/5
        public async Task<ActionResult> HalfHourlyTimesDelete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                HalfHourlyTime halfHourlyTime = await db.HalfHourlyTimes.FindAsync(id);

                if (halfHourlyTime == null)
                {
                    return View("ErrorNotFound");
                }

                return View(halfHourlyTime);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: HalfHourlyTimes/Delete/5
        [HttpPost, ActionName("HalfHourlyTimesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> HalfHourlyTimesDeleteConfirmed(int id)
        {
            try
            {
                HalfHourlyTime halfHourlyTime = await db.HalfHourlyTimes.FindAsync(id);
                db.HalfHourlyTimes.Remove(halfHourlyTime);
                await db.SaveChangesAsync();
                return RedirectToAction("HalfHourlyTimesIndex");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: PaymentModes
        public async Task<ActionResult> PaymentModesIndex()
        {
            try
            {
                return View(await db.PaymentModes.OrderBy(x => x.Name).ToListAsync());
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        // GET: PaymentModes/Details/5
        public async Task<ActionResult> PaymentModesDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);

                if (paymentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(paymentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: PaymentModes/Create
        public ActionResult PaymentModesCreate()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: PaymentModes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PaymentModesCreate([Bind(Include = "PaymentModeId,Name")] PaymentMode paymentMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PaymentModes.Add(paymentMode);
                    await db.SaveChangesAsync();
                    return RedirectToAction("PaymentModesIndex");
                }

                return View(paymentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: PaymentModes/Edit/5
        public async Task<ActionResult> PaymentModesEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);

                if (paymentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(paymentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: PaymentModes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PaymentModesEdit([Bind(Include = "PaymentModeId,Name")] PaymentMode paymentMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(paymentMode).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("PaymentModesIndex");
                }
                return View(paymentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: PaymentModes/Delete/5
        public async Task<ActionResult> PaymentModesDelete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);

                if (paymentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(paymentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: PaymentModes/Delete/5
        [HttpPost, ActionName("PaymentModesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PaymentModesDeleteConfirmed(int id)
        {
            try
            {
                PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);
                db.PaymentModes.Remove(paymentMode);
                await db.SaveChangesAsync();
                return RedirectToAction("PaymentModesIndex");
            }
            catch (Exception ex)
            {

                return View("ErrorNotFound");
            }
        }

        public async Task<ActionResult> ShipmentModesIndex()
        {
            try
            {
                return View(await db.ShipmentModes.OrderBy(x => x.Description).ToListAsync());
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: ShipmentModes/Details/5
        public async Task<ActionResult> ShipmentModesDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }
                
                ShipmentMode shipmentMode = await db.ShipmentModes.FindAsync(id);

                if (shipmentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(shipmentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: ShipmentModes/Create
        public ActionResult ShipmentModesCreate()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: ShipmentModes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ShipmentModesCreate([Bind(Include = "ShipmentId,Description")] ShipmentMode shipmentMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ShipmentModes.Add(shipmentMode);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ShipmentModesIndex");
                }

                return View(shipmentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: ShipmentModes/Edit/5
        public async Task<ActionResult> ShipmentModesEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                ShipmentMode shipmentMode = await db.ShipmentModes.FindAsync(id);

                if (shipmentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(shipmentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: ShipmentModes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ShipmentModesEdit([Bind(Include = "ShipmentId,Description")] ShipmentMode shipmentMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(shipmentMode).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("ShipmentModesIndex");
                }
                return View(shipmentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // GET: ShipmentModes/Delete/5
        public async Task<ActionResult> ShipmentModesDelete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("ErrorBadRequest");
                }

                ShipmentMode shipmentMode = await db.ShipmentModes.FindAsync(id);

                if (shipmentMode == null)
                {
                    return View("ErrorNotFound");
                }

                return View(shipmentMode);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: ShipmentModes/Delete/5
        [HttpPost, ActionName("ShipmentModesDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ShipmentModesDeleteConfirmed(int id)
        {
            try
            {
                ShipmentMode shipmentMode = await db.ShipmentModes.FindAsync(id);
                db.ShipmentModes.Remove(shipmentMode);
                await db.SaveChangesAsync();
                return RedirectToAction("ShipmentModesIndex");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}