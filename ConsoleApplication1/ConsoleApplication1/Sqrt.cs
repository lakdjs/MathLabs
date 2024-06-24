using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Sqrt
    {
        private List <char> _result;
        private List<string> _fullNum;

        public void Calculate(int number){
            _result = new List<char>();
            if(number == 0){
                Console.WriteLine("Корень: " + 0 );
                return;
            }
            if(number == 1){
                
                Console.WriteLine("Корень: " + 1 );
                return;
            }
            _fullNum = new List<string>();
            string stringNum = number.ToString();
            for (int i = stringNum.Length - 1; i >= 0; i -= 2)
            {
                if(i == 0){
                    _fullNum.Add(stringNum[i].ToString());
                    break;
                }
                _fullNum.Add( stringNum[i - 1].ToString() + stringNum[i].ToString() );
            }
            _fullNum.Reverse();
            string ostatok = ""; 
            string n = "";
           
            DevideRecursion(_fullNum[0], ostatok, n);
            Console.WriteLine($"Корень числа {number}: ");
            foreach (var item in _result)
            {
                Console.Write(item + "");
            }
        }


        public void DevideRecursion(string fullStr, string ostatok, string n, int ranks = 0){
            if(fullStr == ""){
                return;
            }
            
            string workStr = ostatok + fullStr;
            string left = "";
            if(n != "")
                 left = (int.Parse(n) * 2).ToString();
            int temp = 0;
                
            for (int i = 0; i <= 10; i++)
             {
                 if(int.Parse(left + i.ToString()) * i > int.Parse(workStr))
                 {
                     temp = int.Parse(left + (i - 1).ToString()) * (i - 1);
                      ostatok = (int.Parse(workStr) - temp).ToString();
                     _result.Add(char.Parse((i - 1).ToString()));
                      n = n + (i - 1).ToString();
                    break;
                }
                    
            }
            for (int i = 0; i < _fullNum.Count; i++)
            {
                if(i == _fullNum.Count - 1 && ostatok == "0"){
                     fullStr = ""; 
                     break;
                }
                if(i == _fullNum.Count - 1 &&  _fullNum[i] == fullStr && ostatok != "0" ){
                    Console.WriteLine("Введите желаемое число разрядов, до которых требуется округлить число");
                    ranks = CorrectNum();
                    fullStr = "00";
                     ranks -= 1;
                     _fullNum[i] = "";  
                     _result.Add(',');
                     break;
                }

                if(_fullNum[i] == fullStr && i < _fullNum.Count - 1){     
                    fullStr = _fullNum[i + 1];
                    _fullNum.RemoveAt(i);
                    break;
                }
                if(i == _fullNum.Count - 1  && ranks == 0 ){
                     
                    fullStr = "";
                     break;
                }
                if(i == _fullNum.Count - 1  && ranks > 0 ){
                    fullStr = "00";
                     ranks -= 1;   
                     break;
                }
                
            }    
            DevideRecursion(fullStr, ostatok, n, ranks);        
        }

        public int CorrectNum(){
            int num = 0;
            var success = false;
            do{
                success = true;
                try{
                    
                    num = int.Parse(Console.ReadLine());
                    if(num < 0)
                        throw new ArgumentException();
                   
                    }catch(FormatException){
                        Console.WriteLine("Вы ввели неверный формат, попробуйте еще раз.");
                        success = false;
                    }catch(ArgumentException){
                        Console.WriteLine("Вы ввели отрицательное число, попробуйте еще раз");
                        success = false;
                    }
            }while(success == false);
            return num;
          
        }
    }
}