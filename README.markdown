guard_claws
=========

A DRY guard clause library designed to provide simple, readable guard clauses. Inspired by this [question on StackOverflow]( http://stackoverflow.com/questions/669678/what-is-the-smoothest-most-appealing-syntax-youve-found-for-asserting-parameter/670495).

Example
==============

NotNullNotBlank
----

    var test = string.Empty;
    Claws.NotNullNotBlank(() => test);
 
Will throw:
 
    GuardClaws.Exceptions.VariableMustNotBeBlankException was unhandled
      Message="Variable must not be blank./n/nDelinquent: test"
      Source="guard_claws"
      NameOfDelinquent="test"

Performance
===========

guard_claws uses code from the [Lokad Shared Libraries](http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html) to gain access to the name of the parameter without having to resort to expression compilation and the runtime costs that incurs. 