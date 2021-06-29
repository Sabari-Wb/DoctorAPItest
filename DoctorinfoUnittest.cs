

using APIDoctorInformation.Controllers;
using APIDoctorInformation.Model;
using APIDoctorInformation.Provider;
using APIDoctorInformation.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace APIDoctorInfoUnittest
{
    [TestFixture]
    public class DoctorinfoUnittest
    {
        Doctor p1;
        Mock<IDoctorProvider> mockdoctorprovider = new Mock<IDoctorProvider>();
        Mock<IDoctorRepo> mockdoctorrepo = new Mock<IDoctorRepo>();

        [SetUp]
        public void setup()
        {
            DateTime d = Convert.ToDateTime("10:00");
            DateTime a = Convert.ToDateTime("11:00");
            p1 = new Doctor(1, "Sanjay", "sivan", "Male", "General", d , a);
            Mock<IDoctorProvider> mockdoctorprovider = new Mock<IDoctorProvider>();
            Mock<IDoctorRepo> mockdoctorrepo = new Mock<IDoctorRepo>();
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
        }
        [Test]

        public void getalldoctordetailstest()
        {


            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(p1);
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.GetDoctorsdetails()).Returns(doctors);
            mockdoctorprovider.Setup(n => n.GetDoctorsdetails()).Returns(doctors);
            //var obj = c.GetDoctorsDetails() as OkObjectResult;
            //Assert.AreEqual(200, obj.StatusCode);

        }


        [Test]

        public void getdoctordetailbyidtest()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.GetDoctorById(1)).Returns(p1);
            mockdoctorprovider.Setup(n => n.GetDoctorById(1)).Returns(p1);
            //  var obj = c.GetDoctorDetailsbyID(1)as OkObjectResult;
            //  Assert.AreEqual(200, obj.StatusCode);
        }
        [Test]
        public void insertdoctordetailtest()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.AddNewDoctor(p1));
            mockdoctorprovider.Setup(n => n.AddNewDoctor(p1));
            //   var obj = c.PostDoctor(p1) as CreatedAtActionResult;
            //   Assert.AreEqual(201, obj.StatusCode);
        }
        [Test]
        public void updatedoctordetailstest()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.UpdateDoctordetail(1, p1));
            mockdoctorprovider.Setup(n => n.UpdateDoctordetail(1, p1));
          //  var obj = c.PutDoctor(1, p1) as NoContentResult;
          //  Assert.AreEqual(204, obj.StatusCode);
        }
        [Test]
        public void deletedoctortest()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.DeleteDoctordetail(1));
            mockdoctorprovider.Setup(n => n.DeleteDoctordetail(1));
          //  var obj = c.DeleteDoctor(1) as NoContentResult;
            //Assert.AreEqual(204, obj.StatusCode);
        }

        //provider unit test
        [Test]
        public void doctordetailsExists()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.DoctordetailExists(1)).Returns(true);
            mockdoctorprovider.Setup(n => n.DoctordetailExists(1)).Returns(true);
            bool obj = p.DoctordetailExists(1);
            Assert.AreEqual(true, obj);
        }
        [Test]
        public void getdoctordetailsbyidTestp()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.GetDoctorById(1)).Returns(p1);
            mockdoctorprovider.Setup(n => n.GetDoctorById(1)).Returns(p1);
            Doctor obj = p.GetDoctorById(1);
            Assert.AreEqual("Sanjay", obj.FirstName);
        }
        [Test]
        public void getalldoctordetailsTestp()
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(p1);
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.GetDoctorsdetails()).Returns(doctors);
            mockdoctorprovider.Setup(n => n.GetDoctorsdetails()).Returns(doctors);
            var obj = p.GetDoctorsdetails();
            Assert.AreEqual(1, obj.Count);
        }
        [Test]
        public void insertdoctordetailtestp()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.AddNewDoctor(p1)).Returns(p1);
            mockdoctorprovider.Setup(n => n.AddNewDoctor(p1)).Returns(p1);
            var obj = p.AddNewDoctor(p1);
            Assert.AreEqual("Sanjay", obj.FirstName);
        }
        [Test]
        public void updatedoctordetailstestp()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.UpdateDoctordetail(1, p1)).Returns(p1);
            mockdoctorprovider.Setup(n => n.UpdateDoctordetail(1, p1)).Returns(p1);
            var obj = p.UpdateDoctordetail(1, p1);
            Assert.AreEqual("Sanjay", obj.FirstName);
        }
        [Test]
        public void deletedoctortestp()
        {
            DoctorProvider p = new DoctorProvider(mockdoctorrepo.Object);
            DoctorsController c = new DoctorsController(mockdoctorprovider.Object);
            mockdoctorrepo.Setup(r => r.DeleteDoctordetail(1));
            mockdoctorprovider.Setup(n => n.DeleteDoctordetail(1));
            p.DeleteDoctordetail(1);

        }

    }
}
