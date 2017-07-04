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
using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.PIDevClub.PIWebApiClient.Api;
using OSIsoft.PIDevClub.PIWebApiClient.Model;

namespace OSIsoft.PIDevClub.PIWebApiClient.Test
{
    /// <summary>
    ///  Class for testing EnumerationValueApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class EnumerationValueApiTests : CommonApi
    {
        private IEnumerationValueApi instance;
        private string webId;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            base.CommonInit();
            instance = client.EnumerationValue;
            base.CreateSampleDatabaseForTests();

            string path = Constants.AF_ENUMERATION_VALUE_PATH;
            string selectedFields = null;
            webId = instance.GetByPath(path, selectedFields).WebId;
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            base.DeleteSampleDatabaseForTests();
        }

        /// <summary>
        /// Test an instance of EnumerationValueApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            Assert.IsInstanceOf(typeof(EnumerationValueApi), instance, "instance is a EnumerationValueApi");
        }

        
        /// <summary>
        /// Test DeleteEnumerationValue
        /// </summary>
        [Test]
        public void DeleteEnumerationValueTest()
        {

            string path = Constants.AF_ENUMERATION_VALUE_PATH;
            instance.DeleteEnumerationValue(webId);
            AFDatabase db = StandardPISystem.Databases[Constants.AF_DATABASE_NAME];
            db.Refresh();
            AFEnumerationValue afEnumValue = AFObject.FindObject(path) as AFEnumerationValue;
            Assert.IsNull(afEnumValue);
            DeleteSampleDatabaseForTests();
            CreateSampleDatabaseForTests();


        
        }
        
        /// <summary>
        /// Test Get
        /// </summary>
        [Test]
        public void GetTest()
        {
            string selectedFields = null;
            var response = instance.Get(webId, selectedFields);
            Assert.IsInstanceOf<PIEnumerationValue>(response, "response is PIEnumerationValue");
        }
        
        /// <summary>
        /// Test GetByPath
        /// </summary>
        [Test]
        public void GetByPathTest()
        {
            string path = Constants.AF_ENUMERATION_VALUE_PATH;
            string selectedFields = null;
            var response = instance.GetByPath(path, selectedFields);
            Assert.IsInstanceOf<PIEnumerationValue>(response, "response is PIEnumerationValue");
        }
        
        /// <summary>
        /// Test UpdateEnumerationValue
        /// </summary>
        [Test]
        public void UpdateEnumerationValueTest()
        {
            string path = Constants.AF_ENUMERATION_VALUE_PATH;
            PIEnumerationValue enumerationValue = instance.GetByPath(path, null);
            enumerationValue.Id = null;
            enumerationValue.Description = "New enumeration value description";
            enumerationValue.Links = null;
            enumerationValue.Path = null;
            enumerationValue.WebId = null;
            instance.UpdateEnumerationValue(webId, enumerationValue);

            StandardPISystem.Refresh();
            AFEnumerationValue afEnumValue = AFObject.FindObject(path) as AFEnumerationValue;
            afEnumValue.Database.Refresh();
            if (afEnumValue != null)
            {
                Assert.IsTrue(afEnumValue.Description == afEnumValue.Description);
            }
        }
        
    }

}