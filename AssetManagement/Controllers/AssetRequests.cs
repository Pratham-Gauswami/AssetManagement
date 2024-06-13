using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Models; // Assuming your models are in the AssetManagement.Models namespace

namespace AssetManagement.Controllers
{
    public class AssetRequestsController : Controller
    {
        private readonly AssetProjectContext _context;

        public AssetRequestsController(AssetProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var assetRequestInfos = await _context.VwAssetRequestsAndEmployeeInfos.ToListAsync();
            return View(assetRequestInfos);
        }

        [HttpGet]
        public IActionResult AddAssetRequest()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> AddAssetRequest(AddAssetRequestViewModel addAssetRequest)
        {
            addAssetRequest.RequestId = GenerateRandomRequestId();

            var assetRequest = new AssetRequest
                {
                    RequestId = addAssetRequest.RequestId,
                    EmpId = addAssetRequest.EmpId,
                    ReqAssetName = addAssetRequest.ReqAssetName,
                    AssetDescription = addAssetRequest.AssetDescription,
                    Reason = addAssetRequest.Reason,
                    DateOfRequest = DateTime.Now // Set the current date/time for DateOfRequest
                };

                _context.AssetRequests.Add(assetRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddAssetRequest");
            

            
        }

        private string GenerateRandomRequestId()
        {
            // Example implementation using Guid
            return Guid.NewGuid().ToString();
        }
    }
}

