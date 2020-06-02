using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawelOwczarekZad1Lab6.Models
{
    /// <summary>
    /// Obiekt autora
    /// </summary>
    public class AuthorViewModel
    {
        //Imie
        public string FirstName { get; set; }
        //Nazwisko
        public string LastName { get; set; }
        //Nick z gita
        public string GitHubName { get; set; }

        //Konstruktor parametryczny
        public AuthorViewModel(string FirstName, string LastName, string GitHubName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.GitHubName = GitHubName;
        }
        //Konstruktor nieparametryczny
        public AuthorViewModel()
        {

        }
    }
}
