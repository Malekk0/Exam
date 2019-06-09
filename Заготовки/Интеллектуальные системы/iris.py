import numpy as np
import matplotlib.pyplot as plt
import sklearn.datasets as ds
from sklearn.model_selection import train_test_split
import math

def sigmoid(x):
    return 1 / (1 + math.exp(-x))

l = 100

iris = ds.load_iris()
X = iris.data[:l,:]
Y = iris.target[:l] * 2 - 1

X = np.concatenate([np.ones((X.shape[0],1)), X], axis=1)

X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size = 0.35)

w = np.random.normal(0.0, 1.0, X.shape[1]);

eps = 0.004
n = 0.01
prev_w = w

dw = eps
while(dw >= eps):
    prev_w = w.copy()
    for j in range(X.shape[1]):
        sum = 0
        for i in range(X_train.shape[0]):
            sum += X_train[i,j] * Y_train[i] * sigmoid(-Y_train[i]*w.dot(X_train[i]))
        w[j] = w[j] + n * (1 / l) * sum
        
    dw = math.sqrt(((prev_w - w)**2).sum())

## for train
Y_predict = X_train.dot(w)
Y_binary = []
for _y in Y_predict:
    Y_binary.append(1 if _y > 0 else -1)

sum = 0
for i in range(Y_train.shape[0]):
    sum += 1 if Y_train[i] == Y_binary[i] else 0
    
A = sum / Y_train.shape[0]
print("Acc for train X: ")
print(A)
##

## for test
Y_predict = X_test.dot(w)
Y_binary = []
for _y in Y_predict:
    Y_binary.append(1 if _y > 0 else -1)

sum = 0
for i in range(Y_test.shape[0]):
    sum += 1 if Y_test[i] == Y_binary[i] else 0
    
A = sum / Y_test.shape[0]
print("Acc for test X: ")
print(A)
##

