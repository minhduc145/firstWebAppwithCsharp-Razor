using Hello.Models;

namespace Hello.ViewModels
{
    public class LopHocViewModel
    {
        public List<LopHoc> listLopHoc { get; set; }

        public List<SinhVien> listSV { get; set; }
        public LopHoc current { get; set; }
        public LopHoc LopHocResponse { get; set; }

    }
}
