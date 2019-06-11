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
    public partial class EditMoviesForm : Form
    {
        public EditMoviesForm()
        {
            InitializeComponent();
        }

        private void EditMoviesForm_Load(object sender, EventArgs e)
        {
            using (DefinitionService definitionService = new DefinitionService())
            {
                cbRecordStatus.DataSource = definitionService.GetRecordStatus();
                cbRecordStatus.DisplayMember = "RecordStatusName";
                cbRecordStatus.ValueMember = "RecordStatusId";


                cbGenre.DataSource = definitionService.GetGenres();
                cbGenre.DisplayMember = "GenreName";
                cbGenre.ValueMember = "GenreId";
            }

            using (MovieService movieService = new MovieService())
            {
                lbMovies.DataSource = movieService.List();
                lbMovies.DisplayMember = "MovieName";
                lbMovies.ValueMember = "MovieId";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MovieService movieService = new MovieService())
            {
                DialogResult dr = MessageBox.Show("Güncellemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    MovieDTO movie = new MovieDTO
                    {
                        MovieId = (int)lbMovies.SelectedValue,
                        MovieName = txtMovieName.Text,
                        GenreId = Convert.ToByte(cbGenre.SelectedValue),
                        DirectorName = txtDirector.Text,
                        ReleaseDate = dateTimePicker1.Value,
                        ImdbScore = Convert.ToByte(txtImdbScore.Text),
                        Quantity = Convert.ToInt32(txtQuantity.Text),
                        UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                        RecordStatusId =Convert.ToByte(cbRecordStatus.SelectedValue),
                        
                        ModifiedBy = 3,
                    
                    };

                    var result = movieService.Update(movie);

                    lbMovies.DataSource = movieService.List();
                    if (result)
                    {
                        MessageBox.Show("Güncelleme başarılı", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void lbMovies_DoubleClick(object sender, EventArgs e)
        {
            var selectedMovie = lbMovies.SelectedItem as MovieDTO;

            using (MovieService movieService= new MovieService())
            {
                var movie = movieService.Get(selectedMovie.MovieId);
                txtMovieName.Text = movie.MovieName;
                cbGenre.SelectedValue = movie.GenreId;
                dateTimePicker1.Value = movie.ReleaseDate;
                txtDirector.Text = movie.DirectorName;
                txtImdbScore.Text = movie.ImdbScore.ToString();
                txtQuantity.Text = movie.Quantity.ToString();
                txtUnitPrice.Text = movie.UnitPrice.ToString();
                cbRecordStatus.SelectedValue = movie.RecordStatusId;

            }
        }
    }
}
