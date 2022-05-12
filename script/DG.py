import numpy
import math

# Line Current of Star Connected DG - Voltage (LN)
def generatorStar(voltage, power):
    I = numpy.divide(power,voltage)
    return I

# Line Current of Delta Connected DG - Voltage (LL)
def generatorStarDelta(voltage, power):
    I = numpy.divide(power,voltage)
    return I
