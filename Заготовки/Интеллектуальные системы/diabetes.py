import numpy as np
import matplotlib.pyplot as plt
import sklearn.datasets as ds
from sklearn.model_selection import train_test_split

diabetes = ds.load_diabetes()
X = diabetes.data
Y = diabetes.target

X = np.concatenate([np.ones((X.shape[0],1)), X], axis=1)

X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size = 0.3)

result = np.linalg.solve(X_train.T.dot(X_train), X_train.T.dot(Y_train))
print("result model: ", result)

###
Y_predict = X_train.dot(result)
R2 = 1 - ((Y_train - Y_predict)**2).sum() / ((Y_train - Y.mean())**2).sum()
print("R2 на train: ", R2)
###

Y_predict = X_test.dot(result)
R2 = 1 - ((Y_test - Y_predict)**2).sum() / ((Y_test - Y.mean())**2).sum()
print("R2 на test: ", R2)

#Plot:
plt.scatter(Y_test, Y_predict)
plt.plot([Y_test.min(), Y_test.max()], [Y_test.min(), Y_test.max()], c='r')
plt.show()
