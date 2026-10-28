using System.Globalization;
using Microsoft.EntityFrameworkCore;
using KiemTra.Models;

namespace KiemTra
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            Environment.GetEnvironmentVariable("ConnectionStrings__DuLieu")
            ?? @"Server=.;Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            Thoat.Click += (_, _) => Close();
            DanhSachSP.SelectionChanged += DanhSachSP_SelectionChanged;
            DanhSachSP.CellClick += DanhSachSP_CellClick;
            Load += Form1_Load;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            Thoat.Enabled = true;
            DanhSachSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DanhSachSP.AutoGenerateColumns = false;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using var context = CreateContext();
                var products = context.SanPhams
                    .AsNoTracking()
                    .OrderBy(product => product.MaSanPham)
                    .ToList();

                DanhSachSP.Rows.Clear();
                foreach (var product in products)
                {
                    DanhSachSP.Rows.Add(product.MaSanPham, product.TenSanPham, product.GiaBan);
                }

                ClearInputs();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"Không thể tải danh sách sản phẩm. Kiểm tra SQL Server và chuỗi kết nối.\n\n{exception.Message}",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DuLieuContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<DuLieuContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new DuLieuContext(options);
        }

        private void DanhSachSP_SelectionChanged(object? sender, EventArgs e)
        {
            var row = DanhSachSP.SelectedRows.Count > 0
                ? DanhSachSP.SelectedRows[0]
                : null;

            ShowSelectedProduct(row);
        }

        private void DanhSachSP_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowSelectedProduct(DanhSachSP.Rows[e.RowIndex]);
            }
        }

        private void ShowSelectedProduct(DataGridViewRow? row)
        {
            var hasSelection = row is not null && !row.IsNewRow && row.Cells[0].Value is not null;
            btnSua.Enabled = hasSelection;
            btnXoa.Enabled = hasSelection;

            if (!hasSelection)
            {
                return;
            }

            txtMaSP.Text = Convert.ToString(row!.Cells[0].Value, CultureInfo.CurrentCulture) ?? string.Empty;
            txtTenSP.Text = Convert.ToString(row.Cells[1].Value, CultureInfo.CurrentCulture) ?? string.Empty;
            txtGiaBan.Text = Convert.ToString(row.Cells[2].Value, CultureInfo.CurrentCulture) ?? string.Empty;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TryReadProduct(out var product))
            {
                return;
            }

            if (MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm sản phẩm này không?",
                    "Xác nhận thêm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var context = CreateContext();
                context.SanPhams.Add(product);
                context.SaveChanges();
                LoadProducts();
                MessageBox.Show("Đã thêm sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException exception)
            {
                MessageBox.Show(
                    $"Không thể thêm sản phẩm. Mã sản phẩm, tên và giá bán phải hợp lệ và không trùng dữ liệu đã có.\n\n{exception.GetBaseException().Message}",
                    "Không thể thêm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                ShowOperationError("thêm", exception);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            var selectedProductId = GetSelectedProductId();
            if (selectedProductId is null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Thiếu sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryReadProduct(out var product))
            {
                return;
            }

            if (MessageBox.Show(
                    "Bạn có chắc chắn muốn lưu thay đổi cho sản phẩm này không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var context = CreateContext();
                var existingProduct = context.SanPhams.Find(selectedProductId);
                if (existingProduct is null)
                {
                    MessageBox.Show("Sản phẩm không còn tồn tại trong cơ sở dữ liệu.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadProducts();
                    return;
                }

                if (product.MaSanPham != existingProduct.MaSanPham)
                {
                    context.SanPhams.Remove(existingProduct);
                    context.SanPhams.Add(product);
                }
                else
                {
                    existingProduct.TenSanPham = product.TenSanPham;
                    existingProduct.GiaBan = product.GiaBan;
                }

                context.SaveChanges();
                LoadProducts();
                MessageBox.Show("Đã sửa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException exception)
            {
                MessageBox.Show(
                    $"Không thể sửa sản phẩm. Tên và giá bán phải hợp lệ và không trùng dữ liệu đã có.\n\n{exception.GetBaseException().Message}",
                    "Không thể sửa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                ShowOperationError("sửa", exception);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            var selectedProductId = GetSelectedProductId();
            if (selectedProductId is null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thiếu sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm {selectedProductId} không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using var context = CreateContext();
                var product = context.SanPhams.Find(selectedProductId);
                if (product is null)
                {
                    MessageBox.Show("Sản phẩm không còn tồn tại trong cơ sở dữ liệu.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadProducts();
                    return;
                }

                context.SanPhams.Remove(product);
                context.SaveChanges();
                LoadProducts();
                MessageBox.Show("Đã xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                ShowOperationError("xóa", exception);
            }
        }

        private bool TryReadProduct(out SanPham product)
        {
            var productId = txtMaSP.Text.Trim();
            var productName = txtTenSP.Text.Trim();
            var rawPrice = txtGiaBan.Text.Trim();

            if (string.IsNullOrWhiteSpace(productId) ||
                string.IsNullOrWhiteSpace(productName) ||
                string.IsNullOrWhiteSpace(rawPrice))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã, tên và giá bán sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product = null!;
                return false;
            }

            if (productId.Length > 10)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 10 ký tự.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product = null!;
                return false;
            }

            if (!TryParsePrice(rawPrice, out var price))
            {
                MessageBox.Show("Giá bán phải là số nguyên hoặc số thực không âm, dùng dấu chấm hoặc dấu phẩy cho phần thập phân.", "Giá bán không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                product = null!;
                return false;
            }

            var normalizedPrice = price.ToString(CultureInfo.InvariantCulture);
            if (normalizedPrice.Length > 12)
            {
                MessageBox.Show("Giá bán không được vượt quá 12 ký tự.", "Giá bán không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                product = null!;
                return false;
            }

            product = new SanPham
            {
                MaSanPham = productId,
                TenSanPham = productName,
                GiaBan = normalizedPrice
            };
            return true;
        }

        private static bool TryParsePrice(string input, out decimal price)
        {
            price = 0;
            if (input.Length == 0)
            {
                return false;
            }

            var separatorIndex = input.IndexOfAny([',', '.']);
            if (separatorIndex >= 0 &&
                (separatorIndex == 0 ||
                 separatorIndex == input.Length - 1 ||
                 input.IndexOfAny([',', '.'], separatorIndex + 1) >= 0))
            {
                return false;
            }

            foreach (var character in input)
            {
                if (!char.IsAsciiDigit(character) && character != ',' && character != '.')
                {
                    return false;
                }
            }

            var normalizedInput = input.Replace(',', '.');
            return decimal.TryParse(
                normalizedInput,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out price);
        }

        private string? GetSelectedProductId()
        {
            var row = DanhSachSP.CurrentRow;
            return row is not null && !row.IsNewRow
                ? Convert.ToString(row.Cells[0].Value, CultureInfo.CurrentCulture)
                : null;
        }

        private void ClearInputs()
        {
            DanhSachSP.ClearSelection();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaSP.Focus();
        }

        private static void ShowOperationError(string operation, Exception exception)
        {
            MessageBox.Show(
                $"Đã xảy ra lỗi khi {operation} sản phẩm.\n\n{exception.Message}",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
