using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;
using ProjektApp.Models;
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

        // GET: AuctionsController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            auctionVMs.Reverse();
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
                Auction auction = _auctionService.CreateAuction(
                    vm.Title, vm.Description,
                    User.Identity.Name,
                    vm.StartingPrice,
                    vm.StartingPrice,
                    vm.ImageUrl
                    );
                _auctionService.Add(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
       }

       // GET: AuctionsController/Edit/5
       public ActionResult Edit(int id, ErrorViewModel accVM)
       {
            Auction auction = _auctionService.GetById(id);
            if (auction == null || !auction.AuctionOwner.Equals(User.Identity.Name))
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
            Auction auction = _auctionService.GetById(id);
            if(auction != null && auction.AuctionOwner.Equals(User.Identity.Name))
            {
                auction.Description = vm.Description;
                _auctionService.UpdateDesc(auction);
                AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
                return RedirectToAction("Details", detailsVM);
            }
            else
            {
                return BadRequest();
            }
       }

        // GET: AuctionsController/Biddings
        public ActionResult BidderList()
        {
            List<Auction> auctions = _auctionService.GetBidderAuctionByUserName(User.Identity.Name);
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            auctionVMs.Reverse();
            return View(auctionVMs);
        }

        // GET: AuctionsController/WinnerList
        public ActionResult WinnerList()
        {
            List<Auction> auctions = _auctionService.GetWinnerList(User.Identity.Name);
            
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            auctionVMs.Reverse();
            return View(auctionVMs);
        }

        // GET: AuctionsController/Bid
        public ActionResult Bid(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if(auction == null || auction.AuctionOwner.Equals( User.Identity.Name)) return BadRequest();
            return View();
        }

        // GET: AuctionsController/Bid/1
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
    }
}
