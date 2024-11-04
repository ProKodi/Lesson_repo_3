namespace _6_lab___C_
{
    public partial class MainWindow : Form
    {
        Fish[] allfish = new Fish[]
        {
            new Fish ("Esox lucius", "�������, ���. �������", "����", true),
            new Fish ("Mugil", "׸����, ��������, �������� ����", "������ (�����)", false),
            new Fish ("Cyprinus carpio", "�������, ���. �������", "�����", true),
            new Fish ("Silurus glanis", "������", "����", true),
            new Fish ("Takifugu rubripes", "�������� ��������� ��������� ����", "��������", false),
            new Fish ("Amphiprion percula", "�������� ����� ������ ������", "����-������", false)
        };
        Fish[] comparefish = new Fish[6];
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < allfish.Length; i++)
            {
                OutputBox.Items.Add(allfish[i].ShowInfo());
            }
        }
        private void Modify_Button_Click(object sender, EventArgs e)
        {
            OutputBox.Items.Clear();
            for (int i = 0; i < allfish.Length; i++)
            {
                if (allfish[i].is_it_freshwater)
                {
                    OutputBox.Items.Add(allfish[i].ShowInfo());
                    comparefish[i] = allfish[i];
                }
            }
            for (int i = 0; i < allfish.Length; i++)
            {
                if (!(allfish[i].is_it_freshwater))
                {
                    OutputBox.Items.Add(allfish[i].ShowInfo());
                    comparefish[i] = allfish[i];
                }
            }
            MessageBox.Show("������ ������������. ������� �������� ������������ ����.", "���������� ���������.");
        }
        private void Compare1_2_Click(object sender, EventArgs e)
        {
            if (comparefish[0] == null)
            {
                if (allfish[0].CompareTo(allfish[1]) == 0)
                {
                    MessageBox.Show("������� �����", "���������");
                }
                else MessageBox.Show("������� �������", "���������");
            }
            else
            {
                if (comparefish[0].CompareTo(comparefish[1]) == 0)
                {
                    MessageBox.Show("������� �����", "���������");
                }
                else MessageBox.Show("������� �������", "���������");
            }
        }
        private void Clone_Button_Click(object sender, EventArgs e)
        {
            if (comparefish[0] == null)
            {
                allfish[5] = (Fish)allfish[1].Clone();
                OutputBox.Items.Clear();
                for (int i = 0; i < allfish.Length; i++)
                {
                    OutputBox.Items.Add(allfish[i].ShowInfo());
                }
                MessageBox.Show("������������� ����������� ���������", "�������� ���������");
            }
            else
            {
                comparefish[5] = (Fish)comparefish[1].Clone();
                OutputBox.Items.Clear();
                for (int i = 0; i < comparefish.Length; i++)
                {
                    OutputBox.Items.Add(comparefish[i].ShowInfo());
                }
                MessageBox.Show("������������� ����������� ���������", "�������� ���������");
            }
        }
        private void Compare2_6_Click(object sender, EventArgs e)
        {
            if (comparefish[0] == null)
            {
                if (allfish[1].CompareTo(allfish[5]) == 0)
                {
                    MessageBox.Show("������� �����", "���������");
                }
                else MessageBox.Show("������� �������", "���������");
            }
            else
            {
                if (comparefish[1].CompareTo(comparefish[5]) == 0)
                {
                    MessageBox.Show("������� �����", "���������");
                }
                else MessageBox.Show("������� �������", "���������");
            }
        }

        private void Upcast_Button_Click(object sender, EventArgs e)
        {
            Animal animal = allfish[3] as Animal;
            Animal animal2 = new Mammal("Felis Catus", "� �����", "�����", 2);
            Animal[] animals = new Animal[2]
            {
                animal,
                animal2
            };
            MessageBox.Show($"���������� �������: ������: {animals[0].ShowInfo()}. ������: {animals[1].ShowInfo()}", "Upcast ��������.");
        }
    }
}
