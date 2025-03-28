using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpEgitimleri301.EFProject
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        csharpEgitimEFTravelDBEntities1 db= new csharpEgitimEFTravelDBEntities1 ();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnList_Click(sender, e);
            var values = db.Guide.Select(x => new
            {
                FullName=x.GuideName+" "+x.GuideSurname,
                x.GuideId
            }).ToList();
            cmxGuide.DisplayMember="Fullname";
            cmxGuide.ValueMember = "GuideId";
            cmxGuide.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values=db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location=new Location();
            location.Capacity =byte.Parse(nudCapacity.Text);
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.DayNight=txtDayNight.Text;
            location.GuideId=int.Parse(cmxGuide.SelectedValue.ToString());
            location.Price = decimal.Parse(txtPrice.Text);
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("gezi başarıyla eklendi","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnList_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var deleteValues = db.Location.Find(int.Parse(txtId.Text));
            db.Location.Remove(deleteValues);
            db.SaveChanges();
            MessageBox.Show("gezi başarıyla silindi","uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnAdd_Click(sender,e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateValues=db.Location.Find(int.Parse(txtId.Text));
            updateValues.Capacity=byte.Parse(nudCapacity.Text);
            updateValues.Country=txtCountry.Text;
            updateValues.DayNight= txtDayNight.Text;
            updateValues.City= txtCity.Text;
            updateValues.GuideId=int.Parse(cmxGuide.SelectedValue.ToString());
            updateValues.Price=decimal.Parse(txtPrice.Text);
            db.SaveChanges();
            MessageBox.Show("gezi başarıyla silindi", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnList_Click(sender,e);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var values=db.Location.Where(x=>x.LocationId==id).ToList();
            dataGridView1.DataSource=values;

        }
    }
}
