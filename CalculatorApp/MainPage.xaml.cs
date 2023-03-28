namespace CalculatorApp;

public partial class MainPage : ContentPage
{
    private string _mainInput = "0";
    private bool _canAddDot=true;
    public string _resultString { get; set; } = "0";
	private ConvertToDouble _convertTODouble;
    private DependencyInsertion _dependencyInsertion;
    private ICalculate _calculate;
    public MainPage()
	{
		InitializeComponent();
        _convertTODouble = new ConvertToDouble();
        _dependencyInsertion = new DependencyInsertion();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var value = (sender as Button).Text;
        switch(value)
        {
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "0":
            case ".":
            case "/":
            case "+":
            case "-":
            case "X":
            case "%":
                ValuesEntered(value);
                break;
            case "C":
                ClearAll();
                break;
            case "=":
                CalculateResult();
                break;
        }
    }
    private void ValuesEntered(string value)
    {
        if(CheckIfOperator(value))
        {
            if(_mainInput.Length==1&&_mainInput=="0")
            {
                _mainInput += value;
            }
            if (CheckIfOperator(_mainInput[_mainInput.Length - 1].ToString()))
            {
                char[] charArray = _mainInput.ToCharArray();
                charArray[charArray.Length - 1] = value.ToCharArray()[0];
                _mainInput = new string(charArray);
            }
            else
            {
                _mainInput += value;
            }
            _canAddDot = true;
        }
        else if (value==".")
        {
            if(_canAddDot)
            {
                _mainInput += value;
                _canAddDot = false;
            }
            else
            {
                return;
            }
        }
        else
        {
            _mainInput += value;
        }
        EnteredText.Text = _mainInput;
    }

   
    private bool CheckIfOperator(string value)
    {
        bool result = false;
        if (value == "+")
            result= true;
        else if(value == "/")
            result = true;
        else if(value =="-")
            result = true;
        else if (value == "X")
            result = true;
        else if (value == "%")
            result = true;
        else result= false;
        return result;

    }

    private void CalculateResult()
    {
        SeparateNumbersAndOperators();
    }

    private void SeparateNumbersAndOperators()
    {
        string[] numbers = _mainInput.Split(new char[] { '+', '-', 'X', '/', '%'});
        List<double> values = new List<double>();
        foreach (string number in numbers)
        {
            double value = _convertTODouble.ToDouble(number);
            values.Add(value);
        }
        List<string> operators= new List<string>();
        foreach(char ope in _mainInput)
        {
            if(CheckIfOperator(ope.ToString()))
            {
                operators.Add(ope.ToString()) ;
            }
        }

        double result = values[0];
        int j = 0;
        for(int i=1;i<values.Count;i++)
        {
            if(j<operators.Count)
            {
                _calculate = _dependencyInsertion.GetObject(operators[j]);
                _calculate.InputOne = result;
                _calculate.InputTwo = values[i];
                result = _calculate.Calculate();
                j++;
            }
            
        }
        ResultText.Text = result.ToString();
    }

    private void ClearAll()
    {
        _resultString= string.Empty;
        EnteredText.Text = string.Empty;
        ResultText.Text = string.Empty;
        _mainInput = "0";
    }
}

