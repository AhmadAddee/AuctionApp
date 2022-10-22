using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;
using ProjektApp.Models;
using ProjektApp.ViewModels;
using System.Net.Http.Headers;

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
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }
        
       // GET: AuctionsController/Details/5
       public ActionResult Details(int id) 
        {
            Auction auction = _auctionService.GetById(id);
            if(auction == null) return NotFound();

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
                    UserName = User.Identity.Name,
                    StartingPrice = vm.StartingPrice,
                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
       }

       // GET: AuctionsController/Edit/5
       public ActionResult Edit(int id, ErrorViewModel accVM)
       {
            Auction auction = _auctionService.GetById(id);
            // check if current user own this auction!
            if (auction == null || !auction.UserName.Equals(User.Identity.Name))
            {
                return BadRequest();
            }
            return View();
       }
        
       // POST: AuctionsController/Edit/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit(int id, AuctionVM vm, ErrorViewModel accVM)
       {
            //if (ModelState.IsValid)
            {
                Auction auction = _auctionService.GetById(id);
                if(auction != null && auction.UserName.Equals(User.Identity.Name))
                {
                    auction.Description = vm.Description;
                    // check if current user own this auction!
                    if (!auction.UserName.Equals(User.Identity.Name)) return BadRequest();
                    _auctionService.UpdateDesc(auction);
                }
                else
                {
                    return BadRequest();
                }
            }
            return RedirectToAction("Index");
       }

        // GET: AuctionsController/Biddings
        public ActionResult BidderList()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetBidderAuctionByUserName(userName);
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/WinnerList
        public ActionResult WinnerList()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetWinnerList(userName);
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: AuctionsController/Bid
        public ActionResult Bid(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (auction == null) return NotFound();
            if(auction.UserName.Equals( User.Identity.Name)) return BadRequest();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(int id, BidVM bidVm)
        {

            var bid = new Bid()
            {
                BidMaker = User.Identity.Name,
                AuctionId = id,
                OfferAmount = bidVm.Offer_Amount,
            };
            
             _auctionService.InitateBid(id, bid);


            Auction auction = _auctionService.GetById(id);
            if (auction == null) return NotFound();
            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return RedirectToAction("Details", detailsVM);
        }


        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
       {
            Auction auctio = _auctionService.GetById(id);
            AuctionVM auctionVM = AuctionVM.FromAuction(auctio);
            return View(auctionVM);
       }

       // POST: AuctionsController/Delete/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Delete(int id, IFormCollection collection)
       {
            _auctionService.Delete(id);
            return RedirectToAction("Index");

        }
        
    }
}
