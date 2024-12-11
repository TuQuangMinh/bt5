using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có giá trị nào được chọn không
            if (toolStripComboBox2.SelectedItem != null)
            {
                // Lấy kích thước chữ từ toolStripComboBox2
                int fontSize;
                if (int.TryParse(toolStripComboBox2.SelectedItem.ToString(), out fontSize))
                {
                    // Cập nhật cỡ chữ cho richTextBox1
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, fontSize, richTextBox1.Font.Style);
                }
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có phông chữ nào được chọn không
            if (toolStripComboBox1.SelectedItem != null)
            {
                // Lấy tên phông chữ từ toolStripComboBox1
                string fontName = toolStripComboBox1.SelectedItem.ToString();

                // Cập nhật phông chữ cho richTextBox1
                if (richTextBox1.SelectionFont != null)
                {
                    // Nếu có văn bản nào được chọn, cập nhật phông chữ cho văn bản đã chọn
                    richTextBox1.SelectionFont = new Font(fontName, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                }
                else
                {
                    // Nếu không có văn bản nào được chọn, cập nhật phông chữ cho văn bản mới
                    richTextBox1.Font = new Font(fontName, richTextBox1.Font.Size, richTextBox1.Font.Style);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có văn bản nào được chọn không
            if (richTextBox1.SelectionFont != null)
            {
                // Lấy phông chữ hiện tại
                Font currentFont = richTextBox1.SelectionFont;

                // Kiểm tra trạng thái in đậm và thay đổi
                FontStyle newFontStyle = currentFont.Bold ? FontStyle.Regular : FontStyle.Bold;

                // Cập nhật phông chữ cho vùng văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, áp dụng phông chữ in đậm cho văn bản mới
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Bold);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {// Kiểm tra xem có văn bản nào được chọn không
            if (richTextBox1.SelectionFont != null)
            {
                // Lấy phông chữ hiện tại
                Font currentFont = richTextBox1.SelectionFont;

                // Kiểm tra trạng thái in nghiêng và thay đổi
                FontStyle newFontStyle = currentFont.Italic ? FontStyle.Regular : FontStyle.Italic;

                // Cập nhật phông chữ cho vùng văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, áp dụng phông chữ in nghiêng cho văn bản mới
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Italic);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có văn bản nào được chọn không
            if (richTextBox1.SelectionFont != null)
            {
                // Lấy phông chữ hiện tại
                Font currentFont = richTextBox1.SelectionFont;

                // Kiểm tra trạng thái gạch dưới và thay đổi
                FontStyle newFontStyle = currentFont.Underline ? FontStyle.Regular : FontStyle.Underline;

                // Cập nhật phông chữ cho vùng văn bản đã chọn
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
            else
            {
                // Nếu không có văn bản nào được chọn, áp dụng phông chữ gạch dưới cho văn bản mới
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Underline);
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TạoVănBảnMới();
        }
        private void TạoVănBảnMới()
        {
            // Xóa nội dung hiện có trong richTextBox1
            richTextBox1.Clear();

            // Đặt lại các giá trị mặc định cho Font và Size
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular); // Thay đổi tên font và size nếu cần

            // Nếu có bất kỳ cài đặt nào khác cần đặt lại, thêm vào đây
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập các thuộc tính cho OpenFileDialog
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn tập tin văn bản";

                // Hiển thị hộp thoại mở tập tin và kiểm tra xem người dùng đã chọn tập tin hay không
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đọc nội dung tập tin và hiển thị trong richTextBox1
                        if (openFileDialog.FileName.EndsWith(".txt"))
                        {
                            richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                        }
                        else if (openFileDialog.FileName.EndsWith(".rtf"))
                        {
                            richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở tập tin: " + ex.Message);
                    }
                }
            }
        }

        private void lưuNộiDụngVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // Nếu là văn bản mới, hiển thị hộp thoại lưu tập tin
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    saveFileDialog.Title = "Lưu nội dung văn bản";

                    // Hiển thị hộp thoại và kiểm tra nếu người dùng nhấn OK
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Lưu nội dung vào tập tin được chọn
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            currentFilePath = saveFileDialog.FileName; // Cập nhật đường dẫn hiện tại
                            isDocumentModified = false; // Đánh dấu là đã lưu
                            MessageBox.Show("Lưu văn bản thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // Nếu văn bản đã được mở trước đó
                try
                {
                    // Lưu lại nội dung vào tập tin hiện tại
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    isDocumentModified = false; // Đánh dấu là đã lưu
                    MessageBox.Show("Văn bản đã được lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
        }
        private bool isDocumentModified = false; 
        private string currentFilePath = string.Empty; 

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thoát khỏi ứng dụng
                Application.Exit();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TạoVănBảnMới();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(currentFilePath))
            {
                // Nếu là văn bản mới, hiển thị hộp thoại lưu tập tin
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    saveFileDialog.Title = "Lưu nội dung văn bản";

                    // Hiển thị hộp thoại và kiểm tra nếu người dùng nhấn OK
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Lưu nội dung vào tập tin được chọn
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            currentFilePath = saveFileDialog.FileName; 
                            isDocumentModified = false; 
                            MessageBox.Show("Lưu văn bản thành công!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                // Nếu văn bản đã được mở trước đó
                try
                {
                    // Lưu lại nội dung vào tập tin hiện tại
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    isDocumentModified = false; 
                    MessageBox.Show("Văn bản đã được lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tập tin: " + ex.Message);
                }
            }
        }
    }
}
