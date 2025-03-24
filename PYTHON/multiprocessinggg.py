  
#multiprocessing is not supported in jupyter notebook thats why we have to idle of python itself
import multiprocessing
import time

def worker(num):
    print(f"Worker {num}")
    time.sleep(1)

if __name__=='__main__':
    jobs=[]
    for i in range(5):
        p=multiprocessing.Process(target=worker,args=(i,))
        jobs.append(p)
        p.start()

    for i in range(5):
        p.join()

        