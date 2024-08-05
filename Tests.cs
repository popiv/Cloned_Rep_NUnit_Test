using NUnit.Framework;
using NUnit;
using System;
using NUnit.Framework.Legacy;
using static Employee;

[TestFixture]
public class EmployeeTests
{
	[Test]
    public void InitialTest()
	{
		var employee = new Employee("milovan",30,5);

		ClassicAssert.AreEqual(200000, employee.BankovniRacun);
	}
    [Test]
    public void TestSpend()
    {
        var employee = new Employee("milovan", 30, 5);

        employee.Spend(200001);
        ClassicAssert.AreEqual(200000,employee.BankovniRacun);

    }

    [Test]
    public void TestSpend2() {

        var employee = new Employee("milovan", 30, 5);
        var spendamount = 23453;
        employee.Spend(spendamount);
        var expected = 200000 - spendamount;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }
    [Test]
    public void Spend_Valid_Amount_Decreasae_BancAccount()
    {

        var employee = new Employee("milovan", 30, 5);
        var spendamount = 500;
        employee.Spend(spendamount);
        var expected = 200000 - spendamount;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }

    [Test]
    public void Spend_ZeroAmount_DoesNotChangeBankAccount()
    {

        var employee = new Employee("milovan", 30, 5);
        var spendamount = 0;
        employee.Spend(spendamount);
        var expected = 200000 - spendamount;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }
 
    [Test]
    public void Earn_PositiveAmount_IncreasesBankAccount()
    {

        var employee = new Employee("milovan", 30, 5);
        var earnamount = 1500;
        employee.Earn(earnamount);
        var expected = 200000 + earnamount;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }

    
    
    [Test]
    public void Earn_ZeroAmount_DoesNotChangeBankAccountunt()
    {

        var employee = new Employee("milovan", 30, 5);
        var earnamount = 0;
        employee.Earn(earnamount);
        var expected = 200000 + earnamount;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }

    
    
    [Test]    
    public void TestDbCount()
    {
        //arrange
        EmployeeDbFake.employeeList = [];

        //act
        var employee = new Employee("milovan", 30, 5);
        var employe1 = new Employee("ivana", 30, 5);
        var employe2 = new Employee("marko", 30, 5);

        //assert
        ClassicAssert.AreEqual(3, EmployeeDbFake.employeeList.Count);
       
    }
    



}
