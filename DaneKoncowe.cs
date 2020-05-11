using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSzkolenieTechniczne
{
    ///<summary>Klasa DaneKoncowey</summary>
    ///<remarks>Klasa ta określa obiekt danych koncowych zamówienia m.in dane dostarczeia zamówienia jak i dane osobowe tóre puzniej trafią do bazy danych</remarks>
    class DaneKoncowe
    {
        ///<summary>Konstruktor bezargumentowy</summary>
        ///<remarks>Konstruktor ten ustawia poszczególne podstawowe wartosci dla Własciwosci obiektu klasy</remarks>
        public DaneKoncowe()
        {
            Miejscowosc = "";
            Kod_pocztowy = "";
            Ulica_NrDomu = "";
            Telefon = "";
            Email = "";
            Nazwisko = "";
            Imie = "";
            FullPricee = 0;
        }

        /// <value>Własciwość FullPricee która pobiera i zwraca Całkowitą cenę zamówienia jako wartość double</value>     
        public double FullPricee { get; set; }

        /// <value>Własciwość Imie która pobiera i zwraca Imie kupującego jako wartość string</value> 
        public string Imie { get; set; }

        /// <value>Własciwość Nazwisko która pobiera i zwraca Nazwisko kupującego jako wartość string</value> 
        public string Nazwisko { get; set; }

        /// <value>Własciwość Email która pobiera i zwraca Email kupującego jako wartość string</value> 
        public string Email { get; set; }

        /// <value>Własciwość Telefon która pobiera i zwraca Telefon kupującego jako wartość string</value> 
        public string Telefon { get; set; }

        /// <value>Własciwość Ulica_NrDomu która pobiera i zwraca  ulice i nr domu zamieszkania kupującego jako wartość string</value> 
        public string Ulica_NrDomu { get; set; }

        /// <value>Własciwość Kod_pocztowy która pobiera i zwraca kod poczotowy kupującego jako wartość string</value> 
        public string Kod_pocztowy { get; set; }
        /// <value>Własciwość Miejscowosc która pobiera i zwraca miejscowość zamieszkania kupującego jako wartość string</value> 
        /// 
        public string Miejscowosc { get; set; }




        ///<summary>Metoda czysczenia własciwosci</summary>
        ///<remarks>Metoda ta odpowiada za przywrócenie poszczególnych wartosci własciwosci do ich stanów sprzed zmiany</remarks>
        public void Usun()
        {
            Miejscowosc = "";
            Kod_pocztowy = "";
            Ulica_NrDomu = "";
            Telefon = "";
            Email = "";
            Nazwisko = "";
            Imie = "";
            FullPricee = 0;

        }
    }

}
