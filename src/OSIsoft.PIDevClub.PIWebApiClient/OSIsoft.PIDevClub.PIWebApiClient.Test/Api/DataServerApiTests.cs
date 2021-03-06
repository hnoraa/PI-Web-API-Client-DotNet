// ************************************************************************
//
// * Copyright 2017 OSIsoft, LLC
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// * 
// *   <http://www.apache.org/licenses/LICENSE-2.0>
// * 
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// ************************************************************************

using NUnit.Framework;
using OSIsoft.PIDevClub.PIWebApiClient.Api;
using OSIsoft.PIDevClub.PIWebApiClient.Model;
using System;
using System.Linq;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing DataServerApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class DataServerApiTests : CommonApi
    {
        private IDataServerApi instance;
        private string webId;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.DataServer;
            webId = instance.GetByName(Constants.DATA_SERVER_NAME).WebId;
            Cleanup();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            base.DeletePIPoint(Constants.PIPOINT_CREATE_NAME);
            base.DeletePIStateSet(Constants.ENUMERATIONSET_CREATE_NAME);  
        }

        /// <summary>
        /// Test an instance of DataServerApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' DataServerApi
            Assert.IsInstanceOf(typeof(DataServerApi), instance, "instance is a DataServerApi");
        }


        /// <summary>
        /// Test CreateEnumerationSet
        /// </summary>
        [Test]
        public void CreateEnumerationSetTest()
        {
            PIEnumerationSet enumerationSet = new PIEnumerationSet()
            {
                Name = Constants.ENUMERATIONSET_CREATE_NAME
            };
            instance.CreateEnumerationSet(webId, enumerationSet);
            Assert.IsNotNull(StandardPIServer.StateSets[Constants.ENUMERATIONSET_CREATE_NAME]);
        }

        /// <summary>
        /// Test CreatePoint
        /// </summary>
        [Test]
        public void CreatePointTest()
        {
            PIPoint pointDTO = new PIPoint
            {
                Name = Constants.PIPOINT_CREATE_NAME,
                Descriptor = "Test for swagger",
                PointClass = "classic",
                PointType = "Float32",
                EngineeringUnits = "",
                Step = false,
                Future = false
            };
            instance.CreatePoint(webId, pointDTO);

            try
            {
                instance.CreatePoint(webId, pointDTO);
                Assert.IsTrue(false);
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }


            OSIsoft.AF.PI.PIPoint piPoint = null;
            var pointFound = OSIsoft.AF.PI.PIPoint.TryFindPIPoint(StandardPIServer, Constants.PIPOINT_CREATE_NAME, out piPoint);
            Assert.IsTrue(pointFound);

        }

        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
   
            string selectedFields = null;
            var response = instance.Get(webId, selectedFields);
            Assert.IsInstanceOf<PIDataServer>(response, "response is PIDataServer");
            Assert.IsTrue(response.Name == Constants.DATA_SERVER_NAME);
        }

        /// <summary>
        /// Test GetByName
        /// </summary>
        [Test]
        public void GetByNameTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string name = Constants.DATA_SERVER_NAME;
            string selectedFields = null;
            var response = instance.GetByName(name, selectedFields);
            Assert.IsInstanceOf<PIDataServer>(response, "response is PIDataServer");
            Assert.IsTrue(response.Name == Constants.DATA_SERVER_NAME);
        }

        /// <summary>
        /// Test GetByPath
        /// </summary>
        [Test]
        public void GetByPathTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string path = Constants.DATA_SERVER_PATH;
            string selectedFields = null;
            var response = instance.GetByPath(path, selectedFields);
            Assert.IsInstanceOf<PIDataServer>(response, "response is PIDataServer");
            Assert.IsTrue(response.Name == Constants.DATA_SERVER_NAME);
        }

        /// <summary>
        /// Test GetEnumerationSets
        /// </summary>
        [Test]
        public void GetEnumerationSetsTest()
        {
            string selectedFields = null;
            var response = instance.GetEnumerationSets(webId, selectedFields);
            Assert.IsInstanceOf<PIItemsEnumerationSet>(response, "response is PIItemsEnumerationSet");
            Assert.IsTrue(StandardPIServer.StateSets.Count == response.Items.Count);

        }

        /// <summary>
        /// Test GetPoints
        /// </summary>
        [Test]
        public void GetPointsTest()
        {
            string nameFilter = "sin*";
            int? startIndex = null;
            int? maxCount = null;
            string selectedFields = null;
            var response = instance.GetPoints(webId, maxCount, nameFilter, selectedFields, startIndex);
            Assert.IsInstanceOf<PIItemsPoint>(response, "response is PIItemsPoint");
            var points = OSIsoft.AF.PI.PIPoint.FindPIPoints(StandardPIServer, "sin*");
            Assert.IsTrue(points.Count() == response.Items.Count);
        }

        /// <summary>
        /// Test List
        /// </summary>
        [Test]
        public void ListTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            string selectedFields = null;
            var response = instance.List(selectedFields);
            Assert.IsInstanceOf<PIItemsDataServer>(response, "response is PIItemsDataServer");
            var server = response.Items.Where(m => m.Name == Constants.DATA_SERVER_NAME).FirstOrDefault();
            Assert.IsNotNull(server);
            Assert.IsTrue(server.Name == Constants.DATA_SERVER_NAME);
        }

    }

}
