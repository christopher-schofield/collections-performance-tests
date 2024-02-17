using HashSetTests;


var objTest1 = new ObjectTests(10000, 10000);
objTest1.Execute();

var objTest2 = new ObjectTests(100000, 100000);
objTest2.Execute();

//This takes a while
//var objTest3 = new ObjectTests(1000000, 1000000);
//objTest3.Execute();



var intTest1 = new IntegerTests(10000, 100000000, 10000);
intTest1.Execute();

var intTest2 = new IntegerTests(100000, 100000000, 100000);
intTest2.Execute();

//var intTest3 = new IntegerTests(1000000, 100000000, 1000000);
//intTest3.Execute();



var stringTest1 = new StringTests(10000, 10000);
stringTest1.Execute();

var stringTest2 = new StringTests(100000, 100000);
stringTest2.Execute();

//This takes a while
//var stringTest3 = new StringTests(1000000, 1000000);
//stringTest3.Execute();