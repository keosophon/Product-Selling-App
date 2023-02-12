using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace A1
{
    /// <summary>
    /// CRUD Implementation for DeliveryType Table
    /// </summary>
    class DeliveryTypeCRUD : ICRUD<DeliveryType>
    {
        private static readonly DBConnection dbConnInstance = DBConnection.GetDBConnInstance();
        private static readonly SqlConnection conn = dbConnInstance.GetConnection();

        public int UpdateObject(DeliveryType deliveryType)
        {
            return -1;
        }
        public void DeleteObject(int id)
        {

        }
        public int Add(DeliveryType deliveryType)
        {
            //not required to implement
            return -1;
        }

        public DeliveryType GetObject(string name)
        {
            //no required to implement

            DeliveryType deliveryType = null;
            return deliveryType;
        }

        public DeliveryType GetObject(int id)
        {
            //no required to implement
            DeliveryType deliveryType = null;



            return deliveryType;
        }

        public List<DeliveryType> GetObjects()
        {
            dbConnInstance.OpenConnection();
            string commandText = "SELECT * FROM DeliveryTypes;";
            List<DeliveryType> deliveryTypeList = new List<DeliveryType>();
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DeliveryType deliveryType = new DeliveryType();
                deliveryType.Id = Convert.ToInt32(reader[0].ToString());
                deliveryType.Mechanism = reader[1].ToString();
                deliveryType.Description = reader[2].ToString();
                deliveryType.ExtraCharge = Convert.ToDecimal(reader[3].ToString());
                deliveryTypeList.Add(deliveryType);

            }
            reader.Close();
            conn.Close();
            return deliveryTypeList;
        }
    }
}