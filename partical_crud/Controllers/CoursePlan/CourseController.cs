using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using partical_crud.Data;
using partical_crud.Models.CourseLearn;

namespace partical_crud.Controllers.CoursePlan
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            var list = await _context.PlanningCourse.ToListAsync();
            return View(list);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(PlanningCourse model)
        //{
        //    try
        //    {
        //        if (model.FormFile.Length > 0 && model.FormFile != null)
        //        {
        //            var getThePath = Path.Combine(_webHostEnvironment.WebRootPath, "Course");

        //            if (Directory.Exists(getThePath))
        //            {
        //                Directory.CreateDirectory(getThePath);
        //            }
        //            byte [] bytes;

        //            string FileName = Path.GetFileName(model.FormFile.FileName);
        //            string filePath = Path.Combine(getThePath, FileName);

        //            using (var stream = new MemoryStream())
        //            {
        //                await model.FormFile.CopyToAsync(stream);
        //                 bytes = stream.ToArray();

        //                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

        //                // Delete the old image if it exists;

        //                if (!string.IsNullOrEmpty(model.ImageName))
        //                {
        //                    var oldFilePath = Path.Combine(FileName, model.ImageName);
        //                    if (System.IO.File.Exists(oldFilePath))
        //                    {
        //                        System.IO.File.Delete(oldFilePath);
        //                    }
        //                }
        //            }

        //            var planningCourse = new PlanningCourse()
        //            {
        //                Data = bytes;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(ex.Message);
        //    }

        //}



        //[HttpPost]
        //public async Task<IActionResult> Edit(PlanningCourse model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.FormFile != null && model.FormFile.Length > 0)
        //        {
        //            try
        //            {
        //                using (var memoryStream = new MemoryStream())
        //                {
        //                    await model.FormFile.CopyToAsync(memoryStream);
        //                    var bytes = memoryStream.ToArray();

        //                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Course");
        //                    if (!Directory.Exists(uploadsFolder))
        //                    {
        //                        Directory.CreateDirectory(uploadsFolder);
        //                    }

        //                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.FormFile.FileName);
        //                    var filePath = Path.Combine(uploadsFolder, fileName);

        //                    await System.IO.File.WriteAllBytesAsync(filePath, bytes);

        //                    // Delete the old image file if it exists
        //                    if (!string.IsNullOrEmpty(model.ImageName))
        //                    {
        //                        var oldFilePath = Path.Combine(uploadsFolder, model.ImageName);
        //                        if (System.IO.File.Exists(oldFilePath))
        //                        {
        //                            System.IO.File.Delete(oldFilePath);
        //                        }
        //                    }

        //                    var currentModel = _context.PlanningCourse.FirstOrDefault(x => x.Id == model.Id);
        //                    if (currentModel != null)
        //                    {
        //                        currentModel.Name = model.Name;
        //                        currentModel.Process = model.Process;
        //                        currentModel.ImageName = fileName;
        //                        currentModel.Data = bytes; // Update the Data property

        //                        _context.Update(currentModel);
        //                        await _context.SaveChangesAsync();
        //                    }

        //                    return RedirectToAction("Index", "Home");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ModelState.AddModelError("", "An error occurred while uploading the file: " + ex.Message);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Please select a file to upload.");
        //        }
        //    }

        //    return View(model);
        //}



        [HttpPost]
        public async Task<IActionResult> Edit(PlanningCourse model)
        {
            if (ModelState.IsValid)
            {
                if (model.FormFile != null && model.FormFile.Length > 0)
                {
                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.FormFile.CopyToAsync(memoryStream);
                            var bytes = memoryStream.ToArray();

                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserProfile");
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.FormFile.FileName);
                            var filePath = Path.Combine(uploadsFolder, fileName);

                            await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                            // Delete the old image file if it exists
                            if (!string.IsNullOrEmpty(model.ImageName))
                            {
                                var oldFilePath = Path.Combine(uploadsFolder, model.ImageName);
                                if (System.IO.File.Exists(oldFilePath))
                                {
                                    System.IO.File.Delete(oldFilePath);
                                }
                            }

                            var currentModel = _context.PlanningCourse.FirstOrDefault(x => x.Id == model.Id);
                            if (currentModel != null)
                            {
                                currentModel.Name = model.Name;
                                currentModel.Process = model.Process;
                                currentModel.ImageName = fileName;
                                currentModel.Data = bytes; // Update the Data property

                                _context.Update(currentModel);
                                await _context.SaveChangesAsync();
                            }

                            return RedirectToAction(actionName: "Index", "Course");

                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "An error occurred while uploading the file: " + ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please select a file to upload.");
                }
            }

            return RedirectToAction(actionName: "Index", "Course");
        }






        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var currentId = _context.PlanningCourse.Where(x => x.Id == Id).FirstOrDefault();
            if (currentId != null)
            {
                _context.PlanningCourse.Remove(currentId);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}
