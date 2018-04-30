using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafeFreightLogisticsApp.Models;

namespace SafeFreightLogisticsApp.Controllers
{
    [Authorize]
    public class Mathely_Logistics_ShipmentsController : Controller
    {
        private SafeFreightDB db = new SafeFreightDB();

        // GET: Shipments
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Shipments.ToListAsync());
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Shipments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View("ErrorBadRequest");
                }

                Shipment shipment = await db.Shipments.FindAsync(id);

                if (shipment == null)
                {
                    //return HttpNotFound();
                    return View("ErrorNotFound");
                }

                return View(shipment);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Shipments/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                ViewBag.TrackingNumber = await GenerateNewUniqueTrackingNumber();
                ViewBag.PackageOrigin = new SelectList(db.Countries.OrderBy(x => x.Name).ToList(), "Name", "Name");
                ViewBag.PackageDestination = new SelectList(db.Countries.OrderBy(x => x.Name).ToList(), "Name", "Name");
                ViewBag.PickupTime = new SelectList(db.HalfHourlyTimes, "TimePeriod", "TimePeriod");
                ViewBag.PaymentMode = new SelectList(db.PaymentModes.OrderBy(x => x.Name).ToList(), "Name", "Name");
                ViewBag.ShipmentMode = new SelectList(db.ShipmentModes.OrderBy(x => x.Description).ToList(), "Description", "Description");

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ShipmentId,TrackingNumber,ShipperName,ShipperAddress,ShipperPhone,ShipperEmail,ReceiverName,ReceiverAddress,ReceiverPhone,ReceiverEmail,Status,PackageOrigin,PackageDestination,CarrierRefNumber,Comments,Product,Quantity,PickupDate,PickupTime,ExpectedDeliveryDate,Weight,PaymentMode,ShipmentMode,CreatedDate,LastModifiedDate")] Shipment shipment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Shipments.Add(shipment);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(shipment);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Shipments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View("ErrorBadRequest");
                }

                Shipment shipment = await db.Shipments.FindAsync(id);

                if (shipment == null)
                {
                    //return HttpNotFound();
                    return View("ErrorNotFound");
                }

                ViewBag.PackageOrigin = new SelectList(db.Countries.OrderBy(x => x.Name).ToList(), "Name", "Name", shipment.PackageOrigin);
                ViewBag.PackageDestination = new SelectList(db.Countries.OrderBy(x => x.Name).ToList(), "Name", "Name", shipment.PackageDestination);
                ViewBag.PickupTime = new SelectList(db.HalfHourlyTimes, "TimePeriod", "TimePeriod", shipment.PickupTime);
                ViewBag.PaymentMode = new SelectList(db.PaymentModes.OrderBy(x => x.Name).ToList(), "Name", "Name", shipment.PaymentMode);
                ViewBag.ShipmentMode = new SelectList(db.ShipmentModes.OrderBy(x => x.Description).ToList(), "Description", "Description", shipment.ShipmentMode);

                return View(shipment);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ShipmentId,TrackingNumber,ShipperName,ShipperAddress,ShipperPhone,ShipperEmail,ReceiverName,ReceiverAddress,ReceiverPhone,ReceiverEmail,Status,PackageOrigin,PackageDestination,CarrierRefNumber,Comments,Product,Quantity,PickupDate,PickupTime,ExpectedDeliveryDate,Weight,PaymentMode,ShipmentMode,CreatedDate,LastModifiedDate")] Shipment shipment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(shipment).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(shipment);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: Shipments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View("ErrorBadRequest");
                }

                Shipment shipment = await db.Shipments.FindAsync(id);

                if (shipment == null)
                {
                    //return HttpNotFound();
                    return View("ErrorNotFound");
                }
                return View(shipment);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Shipment shipment = await db.Shipments.FindAsync(id);
                db.Shipments.Remove(shipment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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

        [AllowAnonymous]
        // GET: Shipments/Search?TrackingNumber="12345-12345"
        public async Task<ActionResult> Search(string TrackingNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TrackingNumber))
                {
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    return View("ErrorBadRequest");
                }

                Shipment shipment = await db.Shipments.SingleOrDefaultAsync(x => x.TrackingNumber == TrackingNumber);

                if (shipment == null)
                {
                    //return HttpNotFound();
                    return View("ErrorNotFound");
                }

                return View(shipment);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [AllowAnonymous]
        // GET: Shipments/CheckTrackingNumber?TrackingNumber="12345-12345"
        public async Task<string> CheckTrackingNumber(string TrackingNumber)
        {
            try
            {
                var shipment = await db.Shipments.SingleOrDefaultAsync(x => x.TrackingNumber == TrackingNumber);

                if (shipment == null)
                {
                    return "Not Found";
                }

                return "Found";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        [AllowAnonymous]
        // GET: Shipments/RefreshSearch?TrackingNumber="12345-12345"
        public async Task<ActionResult> RefreshSearch(string TrackingNumber)
        {
            var shipment = await db.Shipments.SingleOrDefaultAsync(x => x.TrackingNumber == TrackingNumber);

            return PartialView(shipment);
        }

        private async Task<string> GenerateNewUniqueTrackingNumber()
        {
            //Create a 11-character tracking number: XXXXX.XXXXX, and ensure it doesn't already exist in the Shipments table, otherwise create another one
            var newTrackingNumber = "";
            var randomNumber = new Random();

            try
            {
                var trackingNumberInDB = false;
                do
                {
                    for (var i = 0; i < 10; i++)
                    {
                        newTrackingNumber += randomNumber.Next(0, 10).ToString();

                        if (i == 4)  //Make dash the 6th character
                        {
                            newTrackingNumber += "-";
                        }
                    }

                    //Check if this tracking number already exists in the DB
                    trackingNumberInDB = await db.Shipments.AnyAsync(x => x.TrackingNumber == newTrackingNumber);

                } while (trackingNumberInDB);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newTrackingNumber;
        }
    }
}
