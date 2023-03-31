# -*- coding: utf-8 -*-
'''
Unit test for leapyear.py
Student version
'''

import unittest
import leapyear

class KnownValues(unittest.TestCase):
    known_values = (
        (2000, True),
        (1904, True),
        (2400, True),
        (2020, True),
        (2010, False),
        (1900, False),
        (1800, False),
        (2002, False) )
    
    def test_to_leap_year_known_values(self):
        """to_leap_year should give known result with known input"""
        for year, leap in self.known_values:
            result = leapyear.to_leap_year(year)
            self.assertEqual(result,leap)

class LeapYearBadInput(unittest.TestCase):

    def test_negative(self):
        '''to_leap_year should fail with negative input'''
        self.assertRaises(leapyear.OutOfRangeError, leapyear.to_leap_year, -1)
    
    def test_too_large(self):
        '''to_leap_year should fail with large input'''
        self.assertRaises(leapyear.OutOfRangeError, leapyear.to_leap_year, 10000)
        
    def test_zero(self):
        '''to_leap_year should fail with input 0'''
        self.assertRaises(leapyear.OutOfRangeError, leapyear.to_leap_year, 0)
    
    def test_blank(self):
        '''to_leap_year should fail with blank string'''
        self.assertRaises(leapyear.NotIntegerError, leapyear.to_leap_year, "")

    def test_non_integer(self):
        '''to_leap_year should fail with non-integer input'''
        self.assertRaises(leapyear.NotIntegerError, leapyear.to_leap_year, 0.5)

    def test_string(self):
        '''to_leap_year should fail with string input'''
        self.assertRaises(leapyear.NotIntegerError, leapyear.to_leap_year, "s")

if __name__ == '__main__':
    unittest.main()
