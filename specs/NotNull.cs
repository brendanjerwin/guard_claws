using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;
using NUnit.Framework.Constraints;
using System;
using GuardClaws;

namespace NotNull
{
    [TestFixture]
    public class when_calling_NotNull_with_a_not_null_input
    {
		[Test] public void 
		it_should_do_nothing()
        {
            string test = string.Empty;
            Claws.NotNull(() => test);
        }
    }

    [TestFixture]
    public class when_calling_NotNull_with_a_null_input
    {
		ValidationFailureException the_exception;
	
		[SetUp] public void 
		BecauseOf()
        {
            string test = null;
			try{
            	Claws.NotNull(() => test);
			}catch(ValidationFailureException ex){
				the_exception = ex;
			}
        }

		[Test] public void
        it_should_throw_a_GuardClaws_VariableMayNotBeNullException_if_the_input_is_null()
        {
            the_exception.Should().Be.InstanceOf<VariableMayNotBeNullException>();
        }
		
		[Test] public void
        it_should_put_the_variable_name_in_the_exception ()
        {
            the_exception.NameOfDelinquent.Should().Be.EqualTo("test");
        }
		
		[Test] public void
        it_should_put_the_variable_name_in_the_message()
        {
            the_exception.Message.Should().Contain("test");
        }
        
    }


}
