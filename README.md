# Powersets

`PowersetCalculator` is a console app for finding all possible subsets of a given set `S`

For example, when `S = { 1, 2, 3 }`, the output will be: `{{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}`

## Installation 

Just clone or download the repository. This is a simple .Net Core Console App.

## How does it work

As a prerequisute, we want to be able to find the possible combinations of k elements in our set (k=[0..n], where n is the number of elements in the set).

This is done by the pure function `Combinations(int[] set, int k)`

Let's use a simple example to explain the algorithm: 

Our input set is {1,2,3,4,5} with respective indices {0,1,2,3,4}

We want to find, say, the `k = 3` different possible subsets in that set ("combinations"). Maths tells us that the number of possible combinations is given by:

n!/(n-k)!/k! = 10 (for n=5 and k=3)

Let's try to visualise this... It is much easier to work with incides, as by definition, they are always ordered. Therefore, one can write the different combination of **indices** is as follows:

- {0,1,2} let's just pick the first k=3 elements. Let's first try to increase the right most element
- {0,1,3}
- {0,1,4} ok... can't go any further than this, let's increment the next one down. 1 will become 2
- {0,2,3}
- {0,2,4}
- {0,3,4}
- {1,2,3}
- {1,2,4}
- {1,3,4}
- {2,3,4} after that, there's no other index we can increment witout breaching the rules (index on the left is always strictly smaller than its right neighbours AND the index cannot be greater than the size of the set)

The nice thing here is that our indices are **always** in increasing order. We always update the right-most index first, and working our way "down", to the lower indices, making sure all the indices to the right are greater.

With that in mind, the condition for incrementing a given index is:

         `indices[0]`, `indices[1]`, `indices[3]`
                ^           ^           ^
                |           |           |
                |           |           |                
             cannot be      |           |      
             greater than   |           |
               n-2          |           |
                            |           |
                            |           |
                         cannot be      |
                         greater than   |
                           n-1          |
                                        |
                                      cannot be 
                                      greater 
                                      than n (n=4 for a set of size 5)

Code wise, that means that until a given index `indices[j]` (where j=[0..k-1]) reaches indices[j] = j+n-k, the index can be incremented.

## Notes

- The method only handles integers (though this could simply be upgraded to also handle characters)
- The method used here is based on index unicity. If the set contains duplicates, it will treat the duplicate as a unique element.
- The app doesn't allow you to input an empty set (will throw an `ArgumentNullException`) - I thought this was OK, as it's not a very interesting scenario.
- There might be smarter, more elegant methods, such as recursive ones, but I didn't have time to look into these (and I am frankly not sure whether I would have been able to come up with a similar solution)

## Tests

- an empty set returns emtpy subsets {}
- timing the processing a massive set could be interesting. The time complexity of the powerset calculator is O(n*n!)... so it will quickly become slow.

Note that in production environment, I would obviously add a test project (using NUnit for instance), to stress test each of my static functions. I would also have been a bit more careful with the validation and exception handling throughout the code. I was time constrained! 

## Contributors

Valentin Roy (valentin.aj.roy@gmail.com)

## Links

[Python itertools](https://docs.python.org/2/library/itertools.html#itertools.combinations)
