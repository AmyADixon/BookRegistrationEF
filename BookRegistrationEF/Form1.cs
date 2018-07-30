using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Database first as opposed to code first */

namespace BookRegistrationEF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            List<Book> books = BookDB.GetAllBooks();

            PopulateBookComboBox(books);
        }

        private void PopulateBookComboBox(List<Book> books) {
            /* Data binding */
            cbBookList.DataSource = books; // Get all data from the books list
            cbBookList.DisplayMember = nameof(Book.Title); // nameof returns a string which is needed for DisplayMember
        }
    }
}
