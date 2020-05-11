using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSzkolenieTechniczne
{
    ///<summary>Klasa oferty określająca produkty</summary>
    ///<remarks>Klasa ta określa obiekty produktów i ich podstawowe cechy(Właściwości) posiada 2 konstruktory z czego jeden jes bezargumentowy</remarks>
    class Oferty
    {
        ///<summary>Konstruktor bezargumentowy</summary>
       
        public Oferty()
        {

        }
        ///<summary>Konstruktor z trzema argumentami który określa część ze swoich właściwosci tymi argumentami ,nazwę ,cenę oraz zdjęcie</summary>

        public Oferty(string nazwa, double cena, Uri zdj)
        {
            Nazwa = nazwa;

            Cena = cena;
            Zdjecie = zdj;


        }
        /// <value>Własciwość Nazwa która pobiera i zwraca nazwę produktu jako wartość string</value>     
        public string Nazwa { get; set; }


        /// <value>Własciwość Cena która pobiera i zwraca cenę produktu jako wartość double</value>
        public double Cena { get; set; }

        /// <value>Własciwość Zdjecie która pobiera i zwraca Zdjęcie produktu jako obiekt typu Uri</value>

        public Uri Zdjecie { get; set; }


        /// <value>Własciwość Opis która pobiera i zwraca opis produktu jako zmienną typu string</value>

        public string Opis { get; set; }

        /// <value>Własciwość Waga która pobiera i zwraca Wagę produktu jako zmienną typu string</value>
        public string Waga { get; set; }

        /// <value>Własciwość Skladniki która pobiera i składniki  produktu jako zmienną typu string</value>
        public string Skladniki { get; set;}

       




    }
}
