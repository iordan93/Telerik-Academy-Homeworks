using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1._3.World
{
    public partial class World : System.Web.UI.Page
    {
        private const string InvalidContinentError = "Invalid continent name!";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonInsertCity_Click(object sender, EventArgs e)
        {
            this.ListViewCities.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewCities_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewCities.InsertItemPosition = InsertItemPosition.None;
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListViewCities.Visible = true;
        }

        protected void ButtonInsertContinent_Click(object sender, EventArgs e)
        {
            this.PanelInsertContinent.Visible = true;

            this.ButtonSaveContinent.Visible = true;
            this.ButtonEditExistingContinent.Visible = false;
        }

        protected void ButtonSaveContinent_Click(object sender, EventArgs e)
        {
            CreateOrUpdateContinent(true);
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ButtonDeleteContinent.Visible = true;
            this.ButtonEditContinent.Visible = true;
            this.ButtonInsertCountry.Visible = true;
        }

        protected void ButtonDeleteContinent_Click(object sender, EventArgs e)
        {
            using (var db = new WorldEntities())
            {
                var continentToRemove = db.Continents.Find(int.Parse(this.ListBoxContinents.SelectedItem.Value));

                db.Cities.RemoveRange(continentToRemove.Countries.SelectMany(c => c.Cities));
                db.Countries.RemoveRange(continentToRemove.Countries);
                db.Continents.Remove(continentToRemove);
                db.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ButtonEditContinent_Click(object sender, EventArgs e)
        {
            this.PanelInsertContinent.Visible = true;
            this.ButtonEditContinent.Visible = false;

            this.ButtonEditExistingContinent.Visible = true;
            this.ButtonSaveContinent.Visible = false;
        }

        protected void ButtonEditExistingContinent_Click(object sender, EventArgs e)
        {
            CreateOrUpdateContinent(false);
        }

        private void CreateOrUpdateContinent(bool create = true)
        {
            string continentName = this.TextBoxContinentName.Text;
            if (string.IsNullOrEmpty(continentName) || continentName.Length < 3 || continentName == InvalidContinentError)
            {
                this.LiteralErrorMessages.Text = InvalidContinentError;
                return;
            }
            using (var db = new WorldEntities())
            {
                if (create)
                {

                    db.Continents.Add(new Continent()
                    {
                        ContinentName = continentName,
                    });

                    db.SaveChanges();

                }
                else
                {
                    var existingContinent = db.Continents.Find(int.Parse(this.ListBoxContinents.SelectedValue));
                    existingContinent.ContinentName = this.TextBoxContinentName.Text;
                    db.SaveChanges();
                }
            }

            this.ListBoxContinents.DataBind();
            this.PanelInsertContinent.Visible = false;
        }

        protected void ButtonInsertCountry_Click(object sender, EventArgs e)
        {
            this.PanelInsertCountry.Visible = true;
            this.ButtonInsertCountry.Visible = false;
        }

        protected void ButtonSaveCountry_Click(object sender, EventArgs e)
        {
            int continentId = int.Parse(this.ListBoxContinents.SelectedValue);
            string countryName = this.TextBoxCountryName.Text;
            double surfaceArea = double.Parse(this.TextBoxSurfaceArea.Text);
            int population = int.Parse(this.TextBoxPopulation.Text);
            string language = this.TextBoxLanguage.Text;
            double latitude = double.Parse(this.TextBoxLatitude.Text);
            double longitude = double.Parse(this.TextBoxLongitude.Text);

            using (var db = new WorldEntities())
            {
                var continent = db.Continents.Find(continentId);

                byte[] flagAsByteArray = null;
                HttpPostedFile file = this.FileUploadFlagImage.PostedFile;
                flagAsByteArray = new byte[file.ContentLength];
                file.InputStream.Read(flagAsByteArray, 0, file.ContentLength);

                var newCountry = new Country()
                {
                    CountryId = countryName.Substring(0, 3).ToUpper(),
                    Continent = continent,
                    CountryName = countryName,
                    Language = language,
                    Latitude = latitude,
                    Longitude = longitude,
                    Population = population,
                    SurfaceArea = surfaceArea,
                    FlagImage = flagAsByteArray
                };

                db.Countries.Add(newCountry);
                try
                {
                    db.SaveChanges();
                    this.GridViewCountries.DataBind();

                    this.PanelInsertCountry.Visible = false;
                    this.ButtonInsertCountry.Visible = true;
                }
                catch (Exception ex)
                {
                    this.LiteralErrorMessages.Text = ex.Message;
                }
            }
        }

        protected void LinkButtonDeleteCountry_Command(object sender, CommandEventArgs e)
        {
            using (var db = new WorldEntities())
            {
                string countryId = Convert.ToString(e.CommandArgument);
                var countryToRemove = db.Countries
                    .Include(c => c.Cities)
                    .FirstOrDefault(c => c.CountryId == countryId);

                db.Cities.RemoveRange(countryToRemove.Cities);

                db.SaveChanges();
                db.Countries.Remove(countryToRemove);
                db.SaveChanges();

                this.GridViewCountries.DataBind();
            }
        }
    }
}