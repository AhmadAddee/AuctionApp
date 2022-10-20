using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;
using ProjektApp.ViewModels;

namespace ProjektApp.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        /* This method is called from the client browser.
         * Returns completed pure HTML pages to the client browser
         */
        // GET: AuctionsController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List <AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        public string Foo()
        {
            Auction auctions = _auctionService.GetById(-1);
            DateTime dateTime = auctions.CreatedDate;
            var theTestData = $"The time now is: {DateTime.Now} and the created date is: {dateTime} and is expired : {auctions.Bids.Count()}";
            return theTestData.ToString();
        }
        
       // GET: AuctionsController/Details/5
       public ActionResult Details(int id) 
        {
            Auction auction = _auctionService.GetById(id);
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
       }

        
       // GET: AuctionsController/Create
       public ActionResult Create()
       {
           return View();
       }

       // POST: AuctionsController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create(CreateAuctionVM vm)
       {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    StartingPrice = vm.StartingPrice,
                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
       }

        
        

       // GET: AuctionsController/Edit/5
       public ActionResult Edit(int id)
       {
           return View();
       }
        
       // POST: AuctionsController/Edit/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit(int id, AuctionVM vm)
       {
            //if (ModelState.IsValid)
            {
                Auction auction = new Auction(id, vm.Description);
                _auctionService.UpdateDesc( auction);
            }
            return RedirectToAction("Index");
       }
        /*

       // GET: AuctionsController/Delete/5
       public ActionResult Delete(int id)
       {
           return View();
       }

       // POST: AuctionsController/Delete/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Delete(int id, IFormCollection collection)
       {
           try
           {
               return RedirectToAction(nameof(Index));
           }
           catch
           {
               return View();
           }
       }
        */
    }
}
