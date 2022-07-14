# Imports

import socket
import json
import numpy as np
from vector3d import vector, point
from keras.models import load_model

# Loading Model

model = load_model("model.h5")

# Functions for parsing frame joints-data text and convert it to 2D array of angles


# Indexes of joints in each array
ShoulderCenter = 5
ShoulderLeft = 7
ShoulderRight = 6
ElbowLeft = 9
ElbowRight = 8
WristLeft = 11
WristRight = 10
Spine = 1
HipCenter = 2
HipLeft = 4
HipRight = 3
KneeLeft = 15
KneeRight = 14
AnkleLeft = 17
AnkleRight = 16


def getAnglesFromJointsPoints(points):
    anglesArray = []
    # 0 ShoulderSpineLeft
    vShoulderCenterToSpine = vector.from_points(points[ShoulderCenter], points[Spine])
    vShoulderCenterToShoulderLeft = vector.from_points(points[ShoulderCenter], points[ShoulderLeft])
    anglesArray.append(vector.angle(vShoulderCenterToSpine, vShoulderCenterToShoulderLeft))
    # 1 ShoulderSpineRight
    vShoulderCenterToSpine = vector.from_points(points[ShoulderCenter], points[Spine])
    vShoulderCenterToShoulderRight = vector.from_points(points[ShoulderCenter], points[ShoulderRight])
    anglesArray.append(vector.angle(vShoulderCenterToSpine, vShoulderCenterToShoulderRight))
    # 2 ShoulderElbowLeft
    vShoulderLeftToShoulderCenter = vector.from_points(points[ShoulderLeft], points[ShoulderCenter])
    vShoulderLeftToElbowLeft = vector.from_points(points[ShoulderLeft], points[ElbowLeft])
    anglesArray.append(vector.angle(vShoulderLeftToShoulderCenter, vShoulderLeftToElbowLeft))
    # 3 ShoulderElbowRight
    vShoulderRightToShoulderCenter = vector.from_points(points[ShoulderRight], points[ShoulderCenter])
    vShoulderRightToElbowRight = vector.from_points(points[ShoulderRight], points[ElbowRight])
    anglesArray.append(vector.angle(vShoulderRightToShoulderCenter, vShoulderRightToElbowRight))
    # 4 ElbowWristLeft
    vElbowLeftToShoulderLeft = vector.from_points(points[ElbowLeft], points[ShoulderLeft])
    vElbowLeftToWristLeft = vector.from_points(points[ElbowLeft], points[WristLeft])
    anglesArray.append(vector.angle(vElbowLeftToShoulderLeft, vElbowLeftToWristLeft))
    # 5 ElbowWristRight
    vElbowRightToShoulderRight = vector.from_points(points[ElbowRight], points[ShoulderRight])
    vElbowRightToWristRight = vector.from_points(points[ElbowRight], points[WristRight])
    anglesArray.append(vector.angle(vElbowRightToShoulderRight, vElbowRightToWristRight))
    # 6 HipLeftRight
    vHipCenterToHipLeft = vector.from_points(points[HipCenter], points[HipLeft])
    vHipCenterToHipRight = vector.from_points(points[HipCenter], points[HipRight])
    anglesArray.append(vector.angle(vHipCenterToHipLeft, vHipCenterToHipRight))
    # 7 HipKneeLeft
    vHipLeftToHipCenter = vector.from_points(points[HipLeft], points[HipCenter])
    vHipLeftToKneeLeft = vector.from_points(points[HipLeft], points[KneeLeft])
    anglesArray.append(vector.angle(vHipLeftToHipCenter, vHipLeftToKneeLeft))
    # 8 HipKneeRight
    vHipRightToHipCenter = vector.from_points(points[HipRight], points[HipCenter])
    vHipRightToKneeRight = vector.from_points(points[HipRight], points[KneeRight])
    anglesArray.append(vector.angle(vHipRightToHipCenter, vHipRightToKneeRight))
    # 9 KneeAnkleLeft
    vKneeLeftToHipLeft = vector.from_points(points[KneeLeft], points[HipLeft])
    vKneeLeftToAnkleLeft = vector.from_points(points[KneeLeft], points[AnkleLeft])
    anglesArray.append(vector.angle(vKneeLeftToHipLeft, vKneeLeftToAnkleLeft))
    # 10 KneeAnkleRight
    vKneeRightToHipRight = vector.from_points(points[KneeRight], points[HipRight])
    vKneeRightToAnkleRight = vector.from_points(points[KneeRight], points[AnkleRight])
    anglesArray.append(vector.angle(vKneeRightToHipRight, vKneeRightToAnkleRight))
    
    return np.asarray(anglesArray, dtype=np.float32)

def getPointFromCoordinates(joint):
    return point.Point(joint[0], joint[1], joint[2])

def convertJointsArrayToAngles(jointsNpArray):
    pointsNpArray = np.apply_along_axis(getPointFromCoordinates, 1, jointsNpArray)
    anglesNpArray = getAnglesFromJointsPoints(pointsNpArray)
    return anglesNpArray

def parseFrameDataToArray(jointsData):
    jointsData = jointsData[:-1] # the :-1 is to remove the last ";" in the string
    jointsData = jointsData.split(";")
    jointsArray = [x.split(",") for x in jointsData]
    jointsNpArray = np.asarray(jointsArray, dtype=np.float32)
    return jointsNpArray
    
def convertJointsDataStringToAngles(jointsData):
    jointsNpArray = parseFrameDataToArray(jointsData)
    anglesNpArray = convertJointsArrayToAngles(jointsNpArray)
    return anglesNpArray

# Recieving input and predicting

def parseExerciseString(exText):
    exText = exText[:-1] # the :-1 is to remove the last "/" in the string
    allFrames = exText.split("/")
    framesDataInAngles = [convertJointsDataStringToAngles(x) for x in allFrames]
    return framesDataInAngles
    
def stackFramesintoNpArray(framesData, maxTimeSteps, paddingMaskValue):
     # 11 is the numer of features (angles) per frame (Timestep)
    array = np.full((1,maxTimeSteps,11), paddingMaskValue, dtype=np.float32)
    for i in range(len(framesData)):
        array[0:1, i:i+1, 0:len(framesData[i])] = framesData[i]
    return array

def predictExercise(exText):
    framesData = parseExerciseString(exText)
    framePredictableNPArray = stackFramesintoNpArray(framesData, 256, -1)
    predictionMatrix = model.predict(framePredictableNPArray)
    return predictionMatrix

def serializeResult(predictionMatrix):
    predictionMatrix = [round(x,2) for x in predictionMatrix[0].tolist()]
    predictedClassIndex = predictionMatrix.index(max(predictionMatrix))
    predictedClassAccuracy = max(predictionMatrix) * 100
    predictedClass = ""
    if predictedClassIndex == 1:
        predictedClass = "DEAD_LIFT"
    elif predictedClassIndex == 2:
        predictedClass = "TWIST"
    elif predictedClassIndex == 3:
        predictedClass = "LATERAL_RAISE"
    else:
        predictedClass = "NOISE"
    result = {
        "prediction_matrix" : predictionMatrix,
        "predicted_class" : predictedClass,
        "predicted_class_accuracy" : predictedClassAccuracy
    }
    return json.dumps(result)

# Creating Socket

HOST = "127.0.0.1"
PORT = 65435 

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    while True:
        print("WAITING FOR CONNECTION")
        conn, addr = s.accept()
        with conn:
            print("Connected by", addr)
            while True:
                data = conn.recv(1024*1024*100)
                if data:
                    data = data.decode("utf-8")
                    result = serializeResult(predictExercise(data))
                    conn.sendall(bytes((result), 'utf-8'))
                else:
                    break