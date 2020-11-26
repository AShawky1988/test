using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convert_DTO_to_Dynamic_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTOExampleClass DTOobject = new DTOExampleClass();

            DTOobject.First_Name = "Ahmed Shawky";
            DTOobject.Second_Name= "Aiman Ibrahim";
            DTOobject.Third_Name = "Waleed Aly";

            var dynamicList = convertDTOObjectToDynamicList(DTOobject);
            
            dynamicList.ToList().ForEach(x=>
            {
                MessageBox.Show(Convert.ToString(x.FieldName) + " -- " + Convert.ToString(x.FieldValue));
            }); 
        }

        public IEnumerable<dynamic> convertDTOObjectToDynamicList(object DTOobject)
        {
            var dynamicList = DTOobject.GetType().GetFields().Select(x => new
            {
                FieldName = x.Name,
                FieldValue = x.GetValue(DTOobject)
            });
            var notdynamicList = DTOobject.GetType().GetFields().Select(x => Convert.ToString(x.Name));
            return dynamicList;
        }
    }


    public class DTOExampleClass
    {
        public DTOExampleClass()
        {

        }

        public string First_Name;
        public string Second_Name;
        public string Third_Name;
    }
}
