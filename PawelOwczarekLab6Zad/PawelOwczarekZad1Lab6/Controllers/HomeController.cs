using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PawelOwczarekZad1Lab6.Models;

namespace PawelOwczarekZad1Lab6.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        /// <summary>
        /// Strona domowa - funkcja zapytania get przegladarki zwraca widok z atrybutem obiektu autora
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(AppStatic.author);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }
        /// <summary>
        /// Strona kontaktu/autora - funkcja zapytania get przegladarki zwraca widok z atrybutem autora i dodaj do ViewBag właściwość ChangesMade
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            //Zmienia czy w stronie wysłano formularz w celu pokazania alertu
            bool ChangesMade = false;
            ViewBag.ChangesMade = ChangesMade;
            return View(AppStatic.author);
        }
        /// <summary>
        /// Strona kontaktu/autora - funkcja zapytania post wywoływania w momencie wciśnięcia przycisku submit w formularu na stronie
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Contact(AuthorViewModel author)
        {
            ViewData["Message"] = "Your contact page.";
            AppStatic.author = author;
            //Dodanie do viewbag ChangesMade true co pokaże alert
            bool ChangesMade = true;
            ViewBag.ChangesMade = ChangesMade;
            return View(author);
        }
        /// <summary>
        /// Strona wszystkich samolotów - odpowiada na zapytanie get przeglądarki dodaje listę samolotu jako atrybut
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPlanes()
        {
            return View(AppStatic.planes);
        }
        /// <summary>
        /// Strona dodaj samolot - funkcja odpowiada na zapytanie get przeglądarki i zwraca widok
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult addPlane()
        {
            return View();
        }
        /// <summary>
        /// Strona dodaj samolot - funkcja odpowiada na zapytanie post wywołane przyciskiem submit - dodaje samolot do listy i zwraca widok
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult addPlane(PlaneModel plane)
        {
            plane.Photo = "TODO";
            AppStatic.planes.Add(plane);
            return View();
        }

        /// <summary>
        /// Strona usun samolot - usuwa wubrany samolot z listy a nastepnie przekierowywuje na strone GetAllPlanes - nie ma widoku DeletePlane
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeletePlane(string plane)
        {
            foreach (PlaneModel Plane in AppStatic.planes)
            {
                if (Plane.Model == plane)
                {
                    AppStatic.planes.Remove(Plane);
                    break;
                }
            }
            return Redirect("GetAllPlanes");
        }

        /// <summary>
        /// Strona Edit Plane - funckja odpowiada na zapytanie get przeglądarki i zwraca widok dodając jako atrybut obiekt samolotu
        /// </summary>
        /// <param name="planeModel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditPlane(string planeModel)
        {
            PlaneModel plane = new PlaneModel();
            foreach(PlaneModel Plane in AppStatic.planes)
            {
                if (Plane.Model == planeModel) plane = Plane;
            }
            return View(plane);
        }

        /// <summary>
        /// Strona edit plane - funkcja odpowiada na zapytanie post przeglądarki i przekierowywuje na strone GetAllPlanes
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditPlane")]
        public IActionResult EditPlanePost(PlaneModel plane)
        {
            int i = 0;
            foreach(PlaneModel Plane in AppStatic.planes)
            {
                //Znajduje ktory samolot zmodyfikowalismy
                if(Plane.Model==plane.Model)
                {
                    break;
                }
                i++;
            }
            //Modyfikujemy samolot
            AppStatic.planes[i] = plane;
            return Redirect("GetAllPlanes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
