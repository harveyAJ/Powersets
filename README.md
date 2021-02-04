The goal is to find all the possible combinations of elements of a given list (also called "powersets" apparently). 

For an input set of:
{1,2,3,4,5} with respective indices {0,1,2,3,4}

We want to find, say, the `k = 3` different possible combinations. Maths tells us that the number of possible combinations is given by:

n!/(n-k)!/k! = 10 (for n=5 and k=3)

Let's try to visualise this... The different combination of **indices** is as follows:

Let's first increment the right most index:
- {0,1,2}
- {0,1,3}
- {0,1,4} ok... can't go any further than this, let's increment the next one down
- {0,2,3} 
- {0,2,4}
- {0,3,4}
- {1,2,3}
- {1,2,4}
- {1,3,4}
- {2,3,4} after that, there's no other index we can increment witout breaching the rules ()

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
                                      than n (n=4)

Code wise, that means that until a given index `indices[j]` (where j=[0..k-1]) reaches indices[j] = j+n-k, the index can be incremented.


- Only handles integers (though this could simply be upgraded to also handle characters)
- The method used here is based on index unicity
