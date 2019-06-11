using MovieStore.DTO;
using MovieStore.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore.WinUI.Movies
{
    public partial class NewMovieForm : Form
    {
        public NewMovieForm()
        {
            InitializeComponent();
        }
        List<MovieActorDTO> actorsList = new List<MovieActorDTO>();
        private void NewMovieForm_Load(object sender, EventArgs e)
        {
            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatus();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";


                cmbGenre.DataSource = definitionService.GetGenres();
                cmbGenre.DisplayMember = "GenreName";
                cmbGenre.ValueMember = "GenreId";
            }

          
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            MovieActorDTO movieActor = new MovieActorDTO
            {
                FullName=txtActor.Text

            };
            actorsList.Add(movieActor);
            txtActor.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MovieService movieService = new MovieService())
            {
                DialogResult dr = MessageBox.Show("Kaydetmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    MovieDTO movie = new MovieDTO
                    {
                        MovieName = txtMovieName.Text,
                        GenreId = Convert.ToByte(cmbGenre.SelectedValue),
                        DirectorName = txtDirector.Text,
                        ActorList=actorsList,
                        ReleaseDate = dtpRelease.Value,
                        ImdbScore =Convert.ToByte(txtImdb.Text),
                        Quantity = Convert.ToInt32(txtQuantity.Text),
                        UnitPrice=Convert.ToDecimal(txtPrice.Text),
                    
                        CreatedBy = 2
                        
                    };

                    var result = movieService.Add(movie);

                    if (result != null)
                    {
                        MessageBox.Show("Kayıt başarılı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Kayıt sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
