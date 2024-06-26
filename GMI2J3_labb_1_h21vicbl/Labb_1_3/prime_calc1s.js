
/*
student version with NO assertion tests or refactoring implemented
*/
const max = 1000;   // Set upper bounds
const min = 0;      // Set lower bounds
let check4prime;    // global object
let primeBucket = new Array(max + 1); // Initialize array to hold prime numbers

function fillPrimeBucket(){
    check4prime = new Check4Prime();
    for (let i = 2; i <= max; i++) {
        primeBucket[i] = true;
    }
    for (let i = 3; i <= max; i++) {
        // Check if its a multiple of 2
        if (i % 2 === 0) {
            primeBucket[i] = false;
        } 
        // Otherwise check if its a multiple of any the numbers below its own squareroot
        else {
            const sqrt = Math.floor(Math.sqrt(i));
            for (let j = 3; j <= sqrt; j++) {
                if (i % j === 0) {
                    primeBucket[i] = false;
                }
            }
        }
    }
}

class Check4Prime {
    /*
    Calculates prime numbers and put true or false in an array
    */
    primeCheck(num) {
        // Check input against prime array
        if (primeBucket[num] == true) {
            return true;
        }
        else {
            return false;
        }
    }


    /*
    Method to validate input
    */
    checkArgs(input) {
        /*
        for (var i=0; i < arguments.length; i++)
            console.log(arguments[i]);
        */

        // Check arguments for correct number of parameters if not throw new Error();
        if (arguments.length != 1) {
            throw new Error("Du måste ange exakt ett (1) argument")
        }
        else 
        {
            // If undefined throw new Error();
            if (input == undefined){
                throw new Error("Din input kan inte vara undifined")
            } 
            // If zero/empty throw new Error();
            if (input == "") {
                throw new Error("Din input kan inte vara tom")
            }
            
            // Get integer from character
            

            // If not a number throw new Error();
            if ( typeof input !== "number"){
                throw new Error("Du kan bara kolla prime på siffror")
            }


            // Is not integer? throw new Error();
            if (Number.isInteger(input) == false) {
                throw new Error("Din input måste vara ett heltal")
            }
            

            // If less than lower bounds throw new Error();
            if (input < 0) {
                throw new Error("Din input är för låg, får vara lägst 0")
            }
            // If greater than upper bounds throw new Error();
            if (input > 1000) {
                throw new Error("Din input är för hög, får vara högst 1000")
            }
        }
    }
} // end Check4Prime class



/*
do the automated tests cases when developer performs test
*/
function checkTest(num)
{
    check4prime = new Check4Prime();
    // run various automated tests
    test_Check4Prime_known_true();
    test_Check4Prime_known_false();
    test_Check4Prime_checkArgs_neg_input();
    test_Check4Prime_checkArgs_above_upper_bound();
    test_Check4Prime_checkArgs_char_input();
    test_Check4Prime_checkArgs_2_inputs();
    test_Check4Prime_checkArgs_zero_input();
    test_Check4Prime_checkArgs_undefined_input();
    test_Check4Prime_checkArgs_non_integer_input();
}

/*
do the check for prime when ordinary user is running solution, you can merge this function with checkTest() if you want
*/
function check(num)
{
    check4prime = new Check4Prime();

    try {
        //check4prime.checkArgs(num);
        check4prime.checkArgs(parseInt(num));
        // either use this assertion or the alert box for output
        //assert(check4prime.primeCheck(num), description)
        alert(`Is number ${num} a prime? ${check4prime.primeCheck(num)}`)
    }
    catch (err) {
        let description = `Input/number: ${num}. Error in checkArgs()`;
        assert(check4prime.primeCheck(num), description);
    }
}


/*
append test result in list on web page 
*/
function assert(outcome, description) {
    let output = document.querySelector('#output'); 
    let li = document.createElement('li'); 
    li.className = outcome ? 'pass' : 'fail'; 
    li.appendChild(document.createTextNode(description)); 
    output.appendChild(li); 
}

/*
Test methods, recommended naming convention
(Test)_MethodToTest_ScenarioWeTest_ExpectedBehaviour
In test method the pattern we use is "tripple A"
Arrange, Act and Assert
*/


// Test case 1, check known true primes
function test_Check4Prime_known_true() {
    // The arrangement below is called tripple A
	check4prime = new Check4Prime();
	// Arrange - here we initialize our objects
    let known_values_prime = [3, 17, 29, 997]
    // Act - here we act on the objects
    for (i = 0; i < known_values_prime.length; i++) {
        let result = check4prime.primeCheck(known_values_prime[i])
        // Assert - here we verify the result
        assert(result == true,`${known_values_prime[i]}, kollar värdet på kända primtal`)
    }

    
    
}

// Test case 2, check known false primes
function test_Check4Prime_known_false() {
    
    check4prime = new Check4Prime();
    let known_non_prime_values = [0, 4, 27, 49]

    for (i = 0; i < known_non_prime_values.length; i++){
        let result = check4prime.primeCheck(known_non_prime_values[i])
        assert(result == false, `${known_non_prime_values[i]}, kollar värdet på kända komposittal` )
    }
}

// Test case 3, check negative input
function test_Check4Prime_checkArgs_neg_input() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(-1)
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 4, check for upper bound limit
function test_Check4Prime_checkArgs_above_upper_bound() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(1001)
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 5, check for char input
function test_Check4Prime_checkArgs_char_input() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs("r")
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 6, check for more than one input
function test_Check4Prime_checkArgs_2_inputs() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(1, 2)
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 7, check for zero/empty input
function test_Check4Prime_checkArgs_zero_input() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(0)
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 8, check for undefined input
function test_Check4Prime_checkArgs_undefined_input() {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(undefined)
    }
    catch(err) {
        assert(true, err)
    }
}

// Test case 9, check for non-integer input
function test_Check4Prime_checkArgs_non_integer_input() {
    check4prime = new Check4Prime();
    try {
        //check4prime.checkArgs("4.24")
        check4prime.checkArgs(4.24)
    }
    catch(err) {
        assert(true, err)
    }
}