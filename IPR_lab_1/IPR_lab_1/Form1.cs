namespace IPR_lab_1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void ResultButton_Click(object sender, EventArgs e)
		{
			ProgressTextBox.Text = string.Empty;
			try
			{
				List<int> tc = GetNumbers(TcTextBox.Text.Split(','));
				List<int> td = GetNumbers(TdTextBox.Text.Split(','));
				List<int> te = GetNumbers(TeTextBox.Text.Split(','));

				int resFours = 0;
				int resFives = 0;
				int resSix = 0;
				int value = tc.Count * td.Count * te.Count;
				foreach (int c in tc)
				{
					foreach (int d in td)
					{
						foreach (int t_e in te)
						{
							int temp = Math.Max(c + 2, Math.Max(d, t_e + 1));
							if (temp == 4) ++resFours;
							if (temp == 5) ++resFives;
							if (temp == 6) ++resSix;

						}
					}
				}

				ResFourTextBox.Text = ((double)resFours / value).ToString("0.00");
				ResFiveTextBox.Text = ((double)resFives / value).ToString("0.00");
				ResSixTextBox.Text = ((double)resSix / value).ToString("0.00");


				decimal fourDec = (decimal)((double)resFours / value);
				decimal fiveDec = (decimal)((double)resFives / value);
				decimal sixDec = (decimal)((double)resSix / value);

				if ((fourDec > fiveDec) && (fourDec > sixDec))
				{
					if (FourWithoutNumUpDown.Value >= FourWithNumUpDown.Value)
						ResPmpTextBox.Text = "Не используем";
					else
						ResPmpTextBox.Text = "Используем";
				}
				else if ((fiveDec > fourDec) && (fiveDec > sixDec))
				{
					if (FiveWithoutNumUpDown.Value >= FiveWithNumUpDown.Value)
						ResPmpTextBox.Text = "Не используем";
					else
						ResPmpTextBox.Text = "Используем";
				}
				else if ((sixDec > fiveDec) && (sixDec > fourDec))
				{
					if (SixWithoutNumUpDown.Value >= SixWithNumUpDown.Value)
						ResPmpTextBox.Text = "Не используем";
					else
						ResPmpTextBox.Text = "Используем";
				}


				decimal averageWithout = fourDec * FourWithoutNumUpDown.Value + fiveDec * FiveWithoutNumUpDown.Value + sixDec * SixWithoutNumUpDown.Value;
				decimal averageWith = fourDec * FourWithNumUpDown.Value + fiveDec * FiveWithNumUpDown.Value + sixDec * SixWithNumUpDown.Value;
				if (averageWithout >= averageWith)
					ResBayesTextBox.Text = "Нецелесообразно";
				else ResBayesTextBox.Text = "Целесообразно";


				if (SixWithoutNumUpDown.Value >= SixWithNumUpDown.Value)
					ResGarantTextBox.Text = "Нецелесообразно";
				else ResGarantTextBox.Text = "Целесообразно";
			}
			catch (Exception ex)
			{
				ProgressTextBox.Text = ex.Message;
			}
		}

		private void TcTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
			{
				e.Handled = true;
			}
		}

		private void TdTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
			{
				e.Handled = true;
			}
		}

		private void TeTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			char number = e.KeyChar;
			if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
			{
				e.Handled = true;
			}
		}
		private void FourNumUpDown_ValueChanged(object sender, EventArgs e) => FourWithoutNumUpDown.Value = FourNumUpDown.Value;
		
		private void FiveNumUpDown_ValueChanged(object sender, EventArgs e) => FiveWithoutNumUpDown.Value = FiveNumUpDown.Value;

		private void SixNumUpDown_ValueChanged(object sender, EventArgs e) => SixWithoutNumUpDown.Value = SixNumUpDown.Value;



		private List<int> GetNumbers(string[] input)
		{
			List<int> list = new();

			for (int i = 0; i < input.Length; ++i)
			{
				list.Add(Convert.ToInt32(input[i]));
			}

			return list;
		}
	}
}