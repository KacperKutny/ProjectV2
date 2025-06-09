
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ProjectV2.Models;

namespace ProjectV2
{
    public partial class Form1 : Form
    {

        public static int institutionId = Form2.institutionId;
        public Form1()
        {
            InitializeComponent();
            FillClientTypeComboBox();
            FillCarsComboBox();
            FillMechanicTypeComboBox();
            FillDeliveryEmployeeTypeComboBox();
            FillRegisteryEmployeeTypeComboBox();
            FillRentalNumber();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1) || (comboBox2.SelectedIndex == -1) || (comboBox3.SelectedIndex == -1) || (comboBox4.SelectedIndex == -1) || (comboBox5.SelectedIndex == -1) || (string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Please Enter All Data!!");
            } else
            { 
                MessageBox.Show("Succesfully created new Rental!");
                saveData();
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillClientTypeComboBox()
        {
            Client client = new Client { };
            List<Client> clients = new List<Client>();

            clients = client.getClientsList(); 

            foreach (Client singleClient in clients)
            {
                comboBox1.Items.Add(singleClient.ClientID);
            }
        }

        private void FillCarsComboBox()
        {
            Car car = new Car { };
            List<Car> cars = new List<Car>();

            cars = car.getCarsList();

            foreach (Car singleCar in cars)
            {
                comboBox5.Items.Add(singleCar.CarId);
            }
        }
        private void FillMechanicTypeComboBox()
        {
            Mechanic mechanic = new Mechanic { };
            List<Mechanic> mechanics = new List<Mechanic>();

            mechanics = mechanic.getMechanicsList(institutionId);

            foreach (Mechanic singleMechanic in mechanics)
            {
                comboBox2.Items.Add(singleMechanic.EmployeeId);
            }
        }
        private void FillDeliveryEmployeeTypeComboBox()
        {
            DeliveryEmployee de = new DeliveryEmployee { };
            List<DeliveryEmployee> deliveryEmployees = new List<DeliveryEmployee>();

            deliveryEmployees = de.getDeliveryEmployeesList(institutionId);

            foreach (DeliveryEmployee singleDeliveryEmployee in deliveryEmployees)
            {
                comboBox3.Items.Add(singleDeliveryEmployee.EmployeeId);
            }
        }
        private void FillRegisteryEmployeeTypeComboBox()
        {
            RegisteryEmployee re = new RegisteryEmployee { };
            List<RegisteryEmployee> registeryEmployees = new List<RegisteryEmployee>();

            registeryEmployees = re.getRegisteryEmployeesList(institutionId);

            foreach (RegisteryEmployee singleRegisteryEmployee in registeryEmployees)
            {
                comboBox4.Items.Add(singleRegisteryEmployee.EmployeeId);
            }
        }
        private void FillRentalNumber()
        {
            Rental rentall = new Rental();
            label9.Text = Convert.ToString(rentall.getMaxRentalId() + 1);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        void saveData()
        {
            string datetime = dateTimePicker1.Text;
            decimal pricePerDay = Convert.ToDecimal(textBox1.Text);
            int carId = Convert.ToInt32(comboBox5.Text);

            Rental rental = new Rental();
            int rentalId = Convert.ToInt32(label9.Text);
            int mechanicId = Convert.ToInt32(comboBox2.Text);
            int deliveryEmployeeId = Convert.ToInt32(comboBox3.Text);
            int registeryEmployeeId = Convert.ToInt32(comboBox4.Text);
            int clientId = Convert.ToInt32(comboBox1.Text);

            Mechanic mechanic = new Mechanic();
            DeliveryEmployee deliveryEmployee = new DeliveryEmployee();
            RegisteryEmployee registeryEmployee = new RegisteryEmployee();

            Client client = new Client();
            
            rental.saveRental(datetime, pricePerDay, carId);
            mechanic.saveMechanic(mechanicId, rentalId);
            deliveryEmployee.saveDeliveryEmployee(deliveryEmployeeId, rentalId);
            registeryEmployee.saveRegisteryEmployee(registeryEmployeeId, rentalId);
            client.saveClient(datetime, clientId, rentalId); 
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy - MM - dd";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}