using BN1.Data;
using BN1.Data.Entities;
using DevExpress.XtraEditors;
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

namespace BN1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Table1 Entity { get; set; }
        void reSet()
        {
            Entity = null;
            NameTB.EditValue = string.Empty;
            Number.EditValue = 0;
            Desimal.EditValue = 0;
            CreateAt.EditValue = DateTime.Now;
        }
        bool IsValid()
        {
            return true;
        }

        void Create()
        {
            try
            {
                using (var db = new AppDbContxt())
                {
                    db.Table1s.Add(new Table1()
                    {
                        Name = NameTB.Text,
                        Number = Convert.ToInt32(Number.EditValue),
                        Desimal = Convert.ToDecimal(Desimal.EditValue),
                        CreateAt = CreateAt.DateTime,
                    });
                    db.SaveChanges();
                    reSet();
                    GetAll();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        new void Update()
        {
            try
            {
                using (var db = new AppDbContxt())
                {
                    Entity.Name = NameTB.Text;
                    Entity.Number = Convert.ToInt32(Number.EditValue);
                    Entity.Desimal = Convert.ToDecimal(Desimal.EditValue);
                    Entity.CreateAt = CreateAt.DateTime;
                    db.Entry(Entity).State = EntityState.Modified;
                    db.SaveChanges();
                    reSet();
                    GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Delete()
        {
            try
            {
                using (var db = new AppDbContxt())
                {
                    var index = gridView1.GetSelectedRows()[0];
                    var entities = (List<Table1>)gridView1.DataSource;
                    var entity = entities[index];

                    db.Entry(entity).State=EntityState.Deleted;
                    db.SaveChanges();

                    entities.RemoveAt(index);
                    gridControl1.DataSource = entities;
                    gridControl1.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetAll()
        {
            try
            {
                using (var db = new AppDbContxt())
                {
                    var entities = db.Table1s.ToList();
                    gridControl1.DataSource = entities;
                    //gridControl1.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Get()
        {
            var index = gridView1.GetSelectedRows()[0];
            var entities = (List<Table1>)gridView1.DataSource;
            Entity = entities[index];
            NameTB.EditValue = Entity.Name;
            Number.EditValue = Entity.Number;
            Desimal.EditValue = Entity.Desimal;
            CreateAt.EditValue = Entity.CreateAt;
        }



        public Form1()
        {
            InitializeComponent();
            reSet();
            GetAll();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reSet();
        }

        private void colDeleteBtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (XtraMessageBox.Show("هل انت متاكد من الحذف ؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Delete();
        }

        private void colEditBtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Get();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Entity == null)
                Create();
            else
                Update();
        }
    }
}