using IpInfo.Api.Utilities;
using System;
using Xunit;

namespace IpInfo.Api.Test.Utility
{
    public class EnumUtilityTest
    {
        [Fact]
        public void Should_Return_Default_Enum_With_Null()
        {
            // arrange
            string value = null;

            // act
            var result = EnumUtility.ConvertToEnum<TestEnum>(value);

            // assert
            Assert.Equal(TestEnum.Undefined, result);
        }

        [Fact]
        public void Should_Return_Exception_With_Not_Enum_Generic()
        {
            // arrange
            string value = "Test";

            // act
            Exception ex = Assert.Throws<ArgumentException>(() =>
                {
                    var result = EnumUtility.ConvertToEnum<EnumUtilityTest>(value);
                }
            );

            // assert
            Assert.Equal("T must be an enumerated type.", ex.Message);
        }

        [Fact]
        public void Should_Return_Correct_Parsed_With_Valid_Values()
        {
            // arrange
            string value = "MyValue1";

            // act    
            var result = EnumUtility.ConvertToEnum<TestEnum>(value);
            
            // assert
            Assert.Equal(TestEnum.MyValue1, result);
        }

        [Fact]
        public void Should_Return_Default_Enum_With_Unknow_Value()
        {
            // arrange
            string value = "InvalidValue";

            // act    
            var result = EnumUtility.ConvertToEnum<TestEnum>(value);

            // assert
            Assert.Equal(TestEnum.Undefined, result);
        }
    }

    public enum TestEnum
    {
        Undefined,
        MyValue1,
        MyValue2
    }
}
