using Microsoft.AspNetCore.Mvc;
using App.Web.Utils;
using App.Web.Data.Repositories;
using App.Web.ViewModels;
using App.Web.Models;

namespace App.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFolderRepository _folderRepository;

    public HomeController(ILogger<HomeController> logger, IFolderRepository folderRepository)
    {
        _logger = logger;
        _folderRepository = folderRepository;
    }

    public async Task<IActionResult> IndexAsync()
    {
        ViewBag.Data = await GenerateFoldersAsync();

        var viewModel = new HomeIndexViewModel();

        return View(viewModel);   
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(HomeIndexViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var folder = new Folder(viewModel.ParentFolderId, viewModel.FolderName!);

            await _folderRepository.AddAsync(folder);

            return RedirectToAction(nameof(Index));
        }

        ViewBag.Data = await GenerateFoldersAsync();

        return View(viewModel);
    }

    private async Task<List<TreeNode<Guid>>> GenerateFoldersAsync()
    {
        var folders = await _folderRepository.GetllAllAsync();

        var data = new List<TreeNode<Guid>>();

        foreach (var rootFolder in folders.Where(x => x.ParentId is null))
        {
            var rootData = new TreeNode<Guid>
            {
                Id = rootFolder.Id,
                ParentId = default,
                Name = rootFolder.Name,
            };

            data.Add(rootData.BuildTree<Guid>(
                folders.Select(x =>
                new TreeNode<Guid>
                {
                    Id = x.Id,
                    ParentId = x.ParentId ?? default,
                    Name = x.Name

                })
                .ToList()));
        }

        return data;
    }
}