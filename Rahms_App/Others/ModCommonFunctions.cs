using System;
using System.Data;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;

    class ModCommonFunctions
    {
        static ModCommonFunctions sInstance;
        public int CommonId = 0;
        //public List<ClsMonthsMaster> ListofMonth = new List<ClsMonthsMaster>();
        DateTimeFormatInfo mfi = new DateTimeFormatInfo();

        #region "Public Functions"




        public ModCommonFunctions() 
        {
            //StoredProcedures();
        }

        public static ModCommonFunctions Getinstance()
        {
            if (sInstance == null)
            {
                sInstance = new ModCommonFunctions();
            }
            return sInstance;
        }

        #endregion

        //#region "Month Function"

        //public void monthMaster()
        //{
        //    string s = "Frm" ;
        //    String sql = "select * from FeeMonthMaster " ;

        //    DataSet ds = new DataSet();
        //    ds = ClsDBFunctions.GetInstance().ExecuteQuery_DataSet(sql , s );

        //    if (ds != null)
        //    {
        //        List<object> lObj = new List<Object>();
        //        ClsMonthsMaster obj = new ClsMonthsMaster();
        //        lObj = ModCommonFunctions.Getinstance().ConvertDsToList(obj, ds);
        //        if (lObj != null)
        //        {
        //            foreach (ClsMonthsMaster ob in lObj)
        //            {   
                        
        //                ListofMonth.Add(ob);
        //            }
        //        }
        //    }

        //}
        ////---------------
        //// Next Function for generating months is changed by previous monthMaster function
        ////public void GenerateMonthss()
        ////{
        ////    int monthNo;
        ////    for (monthNo = 7; (monthNo <= 12); monthNo++)
        ////    {
        ////        ClsMonthsMaster month = new ClsMonthsMaster();
        ////        // With...
        ////        month.Id = monthNo;
        ////        month.Name= mfi.GetMonthName(monthNo);
        ////        ListofMonth.Add(month);
                
        ////    }
        ////    for (monthNo = 1; (monthNo <= 6); monthNo++)
        ////    {
        ////        ClsMonthsMaster month = new ClsMonthsMaster();
        ////        // With...
        ////        month.Id = monthNo;
        ////        month.Name = mfi.GetMonthName(monthNo);
        ////        ListofMonth.Add(month);
        ////    }
        ////}
        ////--------------------------------------
        //#endregion

        #region "Image conevert functions"

        // functions Commented due to error giveing in output and right function are inserted after these -- 
        // ''' <summary>
        // ''' This function will convert image to string value which is used to store in DB
        // ''' </summary>
        // ''' <param name="img">Image to convert in String</param>
        // ''' <returns>Converted String or blank</returns>
        // ''' <remarks></remarks>
        //public string ImageToString(Image img)
        //{           
        //    string result = "";
        //    try
        //    {
        //        if ((img == null))
        //        {
        //            // TODO: Exit Try: Warning!!! cannot be translated
        //        }
        //        MemoryStream ms = new MemoryStream();
        //        img.Save(ms, ImageFormat.Jpeg);
        //        byte[] picbyte = ms.ToArray();
        //        result = ("0x" + BitConverter.ToString(picbyte).Replace("-", ""));
        //    }
        //    catch (Exception ex)
        //    {
        //        AddToLog(ex);
        //    }
        //    return result;
        //}


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // '' <summary>
        // '' This will convert byte object from DB to image
        // '' </summary>
        // '' <param name="obj">Object(Value) in byte coming from DB. Send it direct to function</param>
        // '' <returns>Image or nothing</returns>
        // '' <remarks></remarks>
       




        //public Image Base64ToImage(string base64String)
        //{
        //    Image result = null;
        //    byte[] imgBytes = Convert.FromBase64String(base64String);
        //    MemoryStream stream = new MemoryStream(imgBytes, 0, imgBytes.Length);

            
        //    Bitmap bmp = new Bitmap(1,1);
        //    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            
        //    //MemoryStream stream = new MemoryStream(imgBytes, 0, imgBytes.Length);
        //    Marshal.Copy(imgBytes, 0, bmpData.Scan0, imgBytes.Length);

        //    bmp.UnlockBits(bmpData);

        //    result = bmp;
        //    return result;

        //}


        public Image StringToImage(string base64String)
        {
            Image result = null;
            try
            {
                //if ((obj == null))
                //{
                //    // TODO: Exit Try: Warning!!! cannot be translated
                //}
                //byte[] imgBytes = ((byte[])(obj));
                byte[] imgBytes = Convert.FromBase64String(base64String);
                //MemoryStream stream = new MemoryStream(imgBytes, 0, imgBytes.Length);
                //MemoryStream ms = new MemoryStream(new Byte[] { 0x00, 0x01, 0x02 });

                MemoryStream ms = new MemoryStream(imgBytes);
                Bitmap returnImage = (Bitmap)Image.FromStream(ms, true, false);

                //System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms, false, false);


                // stream.Position = 0
                result = returnImage;
            }
            catch (Exception ex)
            {
                AddToLog(ex);
            }
            return result;
        } 

        public string ImageToString(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            Image image = Image.FromStream(ms, true, true);
            return image;
        }
        #endregion

        #region "Error Tracing & Log functions"

        public void AddToLog(Exception ex)
        {
            try
            {
                ThreadAbortException th = null;
                if (ex.GetType() == th.GetType())
                {
                    return;
                }
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1);
                System.Diagnostics.StackFrame sf = st.GetFrame(0);
                string callingFile = sf.GetMethod().DeclaringType.FullName.ToString();
                int lnNum = sf.GetFileLineNumber();
                string callingFuncName = sf.GetMethod().Name;
                // check the file
                FileStream fs = new FileStream((Application.StartupPath + "\\errlog.txt"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter s = new StreamWriter(fs);
                s.Close();
                fs.Close();
                // log it
                FileStream fs1 = new FileStream((Application.StartupPath + "\\errlog.txt"), FileMode.Append, FileAccess.Write);
                StreamWriter s1 = new StreamWriter(fs1);
                string msg;
                msg = "Date/Time: " + DateTime.Now.ToString();
                msg = msg + " : " + callingFile;
                msg = msg + " : " + callingFuncName;
                msg = msg + " Line No.: " + lnNum.ToString();
                msg = msg + "\r\n" + "MSG: " + ex.Message;
                msg = msg + "\r\n";
                s1.Write(("================================================" + "\r\n"));
                s1.Write(msg);
                MessageBox.Show(msg);
                s1.Close();
                fs1.Close();
            }
            catch (Exception newEx)
            {
                MessageBox.Show(newEx.Message);
            }
        }
        
        #endregion

        #region "Check Validations"

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = false;
            try
            {
                string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
                Match emailAddressMatch = Regex.Match(emailAddress, pattern);
                // If emailAddressMatch.Success Then result = True
                if (emailAddressMatch.Success)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                AddToLog(ex);
            }
            return result;
        }

        public bool CheckWebSiteUrl(string WebSiturl)
        {
            bool result = false;
            try
            {
                // Dim pattern As String = "http://([\w-]+\.)+[\w-]+(/[w-./?%&=]*)?"
                // Dim webaddressmatch As Match = Regex.Match(WebSiturl, pattern)
                // If webaddressmatch.Success Then result = True
                Regex re = new Regex("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
                Match m = re.Match(WebSiturl);
                if (m.Success)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                AddToLog(ex);
            }
            return result;
        }

        public bool CheckNum(int value)
        {
            bool result = false;
            if ((value >= 65 && value <= 90) || (value >= 97 && value <= 122))
            {

                result = true;
            }

            if (value > 47 && value < 58)
            {
                result = false;
            }
            return result;
        }

        public bool CheckDecimalNum(float value)
        {
            //Allow only digits, decimal, and backspace (char 8)
            bool result = false;

            if (result == true)
            {
                if (value != (char)8)
                {
                    result = true;
                }
            }

            else
            {
                if (value > 47 && value < 58)
                {
                    result = false;
                }
            }

            //Allow only one decimal
            if (value == (char)46)
            {
                result = true;
            }
            return result;
        }

        public bool CheckSpecialCharacter(int value)
        {
            bool result = false;
            if ((value >= 33 && value <= 47) || (value >= 58 && value <= 64) || (value >= 91 && value <= 96) || (value >= 123 && value <= 126))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        ///// <summary>
        ///// This function is used to check whether given char and text makes valid decimal value or not.
        ///// If the given values are 'NOT' decimal then it returns true.
        ///// </summary>
        ///// <param name="ch">Char that is going to add in text</param>
        ///// <param name="txt">Text that adds the given char to form a value</param>
        ///// <returns>Returns 'True' if the value is NOT Decimal otherwise 'False'.</returns>
        ///// <remarks></remarks>
        //public bool Check_DecimalAllow(char ch, string txt)
        //{
        //    bool result = false;
        //    try
        //    {
        //        if (char.IsDigit(ch) == false)
        //        {
        //            switch (Strings.Asc(ch))
        //            {
        //                case 8:
        //                    //Backspace
        //                    break;
        //                case 46:
        //                    // .
        //                    if (Strings.InStr(txt, ".") != 0)
        //                        result = true;

        //                    break;
        //                case 127:
        //                    //DEL
        //                    break;
        //                default:
        //                    result = true;

        //                    break;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        AddToLog(ex);
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// This function is used to check whether given char is valid numeric (without decimal) value or not.
        ///// If the given values are 'NOT' numric then it returns true.
        ///// </summary>
        ///// <param name="ch">Char that is going to add in text</param>
        ///// <returns>Returns 'True' if the value is NOT numeric otherwise 'False'.</returns>
        ///// <remarks></remarks>
        //public bool Check_Numeric(char ch)
        //{
        //    bool result = false;
        //    try
        //    {
        //        if (char.IsDigit(ch) == false)
        //        {
        //            switch (Strings.Asc(ch))
        //            {
        //                case 8:
        //                    //Backspace
        //                    break;
        //                case 127:
        //                    //DEL
        //                    break;
        //                default:
        //                    result = true;

        //                    break;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        AddToLog(ex);
        //    }

        //    return result;
        //}


        #endregion

        #region "Convert dataset to list"

        public List<object> ConvertDsToList(object obj, DataSet ds)
        {
            List<Object> al = new List<Object>();
            Type type1 = obj.GetType();
            object Newobj = new object();
            int i = 0;
            try
            {
                foreach (DataRow drc in ds.Tables[0].Rows)
                {
                    object[] args = new object[] { 1-1 };
                    args = drc.ItemArray;

                    //  Get the constructor that takes an integer as a parameter.
                    // Dim constructorInfoObj As ConstructorInfo = type1.GetConstructor(args)
                    // Dim getinst = type1.GetConstructor(args)
                    //  Get the public properties.
                    //object[] inst = null;
                     Newobj  = (object)Activator.CreateInstance(type1);
                    //Newobj = inst;

                    PropertyInfo[] myPropertyInfo = new PropertyInfo[1];
                       myPropertyInfo= type1.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    //inst = drc.ItemArray;
                    for (i = 0; (i <= (myPropertyInfo.Length - 1)); i++)
                    {
                         if ((object)args[i] != System.DBNull.Value)
                        {
                            myPropertyInfo[i].SetValue(Newobj, args[i], BindingFlags.SetProperty, null, null, null);
                        }
                    }
                    al.Add(Newobj);
                }
            }
            catch (Exception ex)
            {
                ModCommonFunctions.Getinstance().AddToLog(ex);
            }
            return al;
        }

        #endregion

        #region " Reset Controls"

        public static void ResetFields(Control form)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.Controls.Count > 0)
                    ResetFields(ctrl);
                Reset(ctrl);
            }
        }
        public static void Reset(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                if (tb != null)
                {
                    tb.ResetText();
                }
            }
            else if (ctrl is ComboBox)
            {
                ComboBox dd = (ComboBox)ctrl;
                if (dd != null)
                {
                    if (dd.DataSource != null)
                        dd.SelectedIndex = -1;
                    else
                        dd.Text = "";
                }
            }
            else if (ctrl is DataGridView)
            {
                DataGridView DG = (DataGridView)ctrl;
                if (DG != null)
                {
                        DG.DataSource = null;
                        DG.Rows.Clear();
                }
            }
            else if (ctrl is MaskedTextBox)
            {
                MaskedTextBox MTB = (MaskedTextBox)ctrl;
                if (MTB != null)
                {
                    MTB.Text = "";
                }
            }
            //else if (ctrl is CheckedListBox)
            //{
            //    CheckedListBox CHK = (CheckedListBox)ctrl;
            //    if (CHK != null)
            //    {
            //        CHK.DataSource = null;
            //    }
            //}

        }
        #endregion

        #region "GetNameForId"

        //public string GetName(object obj, int id)
        //{
        //string name = "";
        //Type type1 = obj.GetType();
        //object Newobj = new object();
        //Newobj = (object)Activator.CreateInstance(type1);
        //    try
        //    {
        //        MemberInfo[] myMemberInfo = new MemberInfo[1];                
        //        myMemberInfo = type1.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                
        //        for (int i = 0; (i <= (myMemberInfo.Length - 1)); i++)
        //        {
        //            if (myMemberInfo[i].Name.Contains("getAll"))
        //            {
        //                //myMemberInfo[i].
                        
        //            }
        //            //if ((object)args[i] != System.DBNull.Value)
        //            //{
        //            //    myMemberInfo[i].SetValue(Newobj, args[i], BindingFlags.SetProperty, null, null, null);
        //            //}
        //        }
        //        //al.Add(Newobj);
        //        //foreach (Object Obj in list)
        //        //{
        //        //    if (Obj.Id = id)
        //        //    {
        //        //        name = Obj.Name;
        //        //        return name;
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        AddToLog(ex.Message.ToString());
        //    }
        //    return name;
        //}

        //public DataRowView GetObj(int Value, ref ComboBox Cmb)
        //{
        //    DataRowView Obj = null;
        //    try
        //    {
        //        foreach (DataRowView item in Cmb.Items)
        //        {
        //            if (item[ModConstants.GetInstance().cId] == Value)
        //            {
        //                Obj = item;
        //                break; // TODO: might not be correct. Was : Exit Try
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        AddToLog(ex);
        //    }

        //    return Obj;
        //}

        #endregion 

        public Cls_Login UserTypes = new Cls_Login();


    }
