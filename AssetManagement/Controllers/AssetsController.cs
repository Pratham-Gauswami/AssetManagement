namespace AssetManagement.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Models; // Assuming your models are in the AssetManagement.Models namespace

    public class AssetsController : Controller
    {

        public AssetProjectContext AssetprojContext { get; }

        public AssetsController(AssetProjectContext assetprojContext)
        {
            AssetprojContext = assetprojContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var assets = await AssetprojContext.Assets.ToListAsync();
            return View(assets);
        }

        [HttpGet]
        public IActionResult AddAsset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AddAssetViewModel addAssetRequest)
        {
            var asset = new Asset()
            {
                AssetId = addAssetRequest.AssetId,
                AssetName = addAssetRequest.AssetName,
                ModelNo = addAssetRequest.ModelNo,
                SerialNo = addAssetRequest.SerialNo,
                MakeCompany = addAssetRequest.MakeCompany,
                Value = addAssetRequest.Value,
                Status = addAssetRequest.Status,
                

            };

            await AssetprojContext.Assets.AddAsync(asset);
            await AssetprojContext.SaveChangesAsync();
            return RedirectToAction("AddAsset");

        }

        [HttpGet]
        public async Task<IActionResult> View(string AssetId)
        {
            var asset = await AssetprojContext.Assets.FirstOrDefaultAsync(x => x.AssetId == AssetId);

            if (asset != null)
            {
                var viewModel = new UpdateAssetViewModel()
                {
                    AssetId = asset.AssetId,
                    AssetName = asset.AssetName,
                    ModelNo = asset.ModelNo,
                    SerialNo = asset.SerialNo,
                    MakeCompany = asset.MakeCompany,
                    Value = asset.Value,
                    Status = asset.Status,
                    
                };
                return await Task.Run(() => View("View", viewModel));
            }



            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAssetViewModel model)
        {
            // Retrieve the employee from the database
            var asset = await AssetprojContext.Assets.FindAsync(model.AssetId);

            if (asset != null)
            {
                // Update asset properties
                asset.AssetId = model.AssetId;
                asset.AssetName = model.AssetName;
                asset.ModelNo = model.ModelNo;
                asset.SerialNo = model.SerialNo;
                asset.MakeCompany = model.MakeCompany;
                asset.Value = model.Value;
                

                // Mark the entity as modified
                AssetprojContext.Entry(asset).State = EntityState.Modified;

                // Save changes to the database
                await AssetprojContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAssetViewModel model)
        {
            var asset = await AssetprojContext.Employees.FindAsync(model.AssetId);

            if (asset != null)
            {
                AssetprojContext.Employees.Remove(asset);
                await AssetprojContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }

