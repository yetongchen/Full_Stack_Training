// Practice number sizes and ranges

// 1.
Console.WriteLine("Understanding Types:");
// sbyte
Console.WriteLine($"sbyte: {sizeof(sbyte)} bytes, Min: {sbyte.MinValue}, Max: {sbyte.MaxValue}");
// byte
Console.WriteLine($"byte: {sizeof(byte)} bytes, Min: {byte.MinValue}, Max: {byte.MaxValue}");
// short
Console.WriteLine($"short: {sizeof(short)} bytes, Min: {short.MinValue}, Max: {short.MaxValue}");
// ushort
Console.WriteLine($"ushort: {sizeof(ushort)} bytes, Min: {ushort.MinValue}, Max: {ushort.MaxValue}");
// int
Console.WriteLine($"int: {sizeof(int)} bytes, Min: {int.MinValue}, Max: {int.MaxValue}");
// uint
Console.WriteLine($"uint: {sizeof(uint)} bytes, Min: {uint.MinValue}, Max: {uint.MaxValue}");
// long
Console.WriteLine($"long: {sizeof(long)} bytes, Min: {long.MinValue}, Max: {long.MaxValue}");
// ulong
Console.WriteLine($"ulong: {sizeof(ulong)} bytes, Min: {ulong.MinValue}, Max: {ulong.MaxValue}");
// float
Console.WriteLine($"float: {sizeof(float)} bytes, Min: {float.MinValue}, Max: {float.MaxValue}");
// double
Console.WriteLine($"double: {sizeof(double)} bytes, Min: {double.MinValue}, Max: {double.MaxValue}");
// decimal
Console.WriteLine($"decimal: {sizeof(decimal)} bytes, Min: {decimal.MinValue}, Max: {decimal.MaxValue}");


// 2. 
Console.Write("Enter number of centuries: ");
int centuries = int.Parse(Console.ReadLine());

// Constants
int yearsInCentury = 100;
decimal daysInYear = 365.2422m;
int hoursInDay = 24;
int minutesInHour = 60;
int secondsInMinute = 60;
int millisecondsInSecond = 1000;
int microsecondsInMillisecond = 1000;
int nanosecondsInMicrosecond = 1000;

// Calculations
long years = centuries * yearsInCentury;
long days = (long)(years * daysInYear);
long hours = days * hoursInDay;
long minutes = hours * minutesInHour;
long seconds = minutes * secondsInMinute;
long milliseconds = seconds * millisecondsInSecond;
long microseconds = milliseconds * microsecondsInMillisecond;
decimal nanoseconds = (decimal)microseconds * nanosecondsInMicrosecond;

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
