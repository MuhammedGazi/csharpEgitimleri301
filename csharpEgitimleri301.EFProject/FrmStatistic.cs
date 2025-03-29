using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpEgitimleri301.EFProject
{
    public partial class FrmStatistic: Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }
        csharpEgitimEFTravelDBEntities1 db =new csharpEgitimEFTravelDBEntities1();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            //toplam lokasyon sayısı
            lblLocationCount.Text=db.Location.Count().ToString();

            //toplam kapasite
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();

            //toplam rehber sayısı
            lblGuideSum.Text=db.Location.Count().ToString();

            //ortalama kapasite
            lblAvarageCapacity.Text = db.Location.Average(x => x.Capacity).ToString();

            //ortalama fiyat
            lblAvaragePrice.Text=db.Location.Average(x=>x.Price).ToString();

            //son eklenen üke
            int id = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == id).Select(y => y.Country).FirstOrDefault();

            //seçilen turun kapasitesi

            //seçilen ülkenin ortalama kapasitesi

            //seçilen turun rehber ismi

            //en yüksek kapasiteli tur
            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacity.Text = db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            //en pahalı tur
            var maxPrice=db.Location.Max(x=>x.Price);
            lblMaxPrice.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            //seçilen rehberin lokasyon sayısı

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
