using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSzkolenieTechniczne
{
  /// <summary> Klasa która dziedziczy po klasie Oferty i jest klasą ogkreślającą produkty które zostały zamówione przez kkienta  </summary>
  ///<remarks> Klasa przyjmuje ogkreślone wartosci produktu oraz pośada możliwość pobrania ich dzięki akcesorowi get własciwości</remarks>
    class ProduktyZamowione:Oferty
    {
        /// <summary> Podstawowy konstruktor klasy,przyjmuje parametry króte będą definiować produkt oraz wywołuje konstruktor klasy podstawowej z 3 parametrami  </summary>
        /// <example>
        /// <code>
        /// ProduktyZamowione ob1= new ProduktyZamowione("nazwa1",50,"sciezka",3,150);
        /// 
        /// </code>
        /// </example>
        public ProduktyZamowione(string nazwa,double cena,Uri zdj,int ilosc,double cenaAll):base(nazwa,cena,zdj)
        {
            this.Ilosc = ilosc;
            this.CenaAll = cenaAll;

        }


        /// <value>Właściwość pobiera oraz zwraca wartość int określającą ilość szt. produktu jednego typu</value>
        public int Ilosc { get; set; }

        /// <value>Właściwość pobiera oraz zwraca wartość double określającą całkowitą cene danego produktu zamówionego tj Cena(z klasy podstawowej * Ilosc)</value>
        public double CenaAll { get; set;}
    }
}
