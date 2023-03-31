# -*- coding: utf-8 -*-
'''
There is a leap year every year whose number is perfectly divisible by four - 
except for years which are both divisible by 100 and not divisible by 400. 
The second part of the rule effects century years. 
For example; the century years 1600 and 2000 are leap years, 
but the century years 1700, 1800, and 1900 are not.
'''


class NotIntegerError(ValueError):
    pass


class OutOfRangeError(ValueError):
    pass


def to_leap_year(year):
    '''Python program to check if the input year is a leap year or not'''
    if year == "":
        raise NotIntegerError("Input can not be blank")

    if not isinstance(year, int):
        raise NotIntegerError("Non-integers can not be an year...")
    
    if not 0 < int(year) < 10000:
        raise OutOfRangeError(
            "Year out of range, please check year 1 ... 9999")

    
    if (year % 4 == 0):
        if (year % 100 == 0 and year % 400 != 0):
            return False
        else:
            return True
    else:
        return False


if __name__ == '__main__':
    to_leap_year_input = int(input("Enter a year to test if it's a leapyear: "))
    try:
        print(f"Is year {to_leap_year_input} a leap year?  " + str(to_leap_year(to_leap_year_input)))
    except ValueError:
        print("Input must be integer")
