guard_claws
=========

A DRY guard clause library designed to provide simple, readable guard clauses. Inspired by this [question on StackOverflow]( http://stackoverflow.com/questions/669678/what-is-the-smoothest-most-appealing-syntax-youve-found-for-asserting-parameter/670495).

Some Examples:
==============

  var test = string.Empty;
  Claws.NotNullNotBlank(() => test);
 
 Will throw:
 
   GuardClaws.Exceptions.VariableMustNotBeBlankException was unhandled
    Message="Variable must not be blank./n/nDelinquent: test"
    Source="guard_claws"
    NameOfDelinquent="test"