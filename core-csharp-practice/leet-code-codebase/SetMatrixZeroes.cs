public class Solution {
    public void SetZeroes(int[][] matrix) {
        int n = matrix.Length;
        int m = matrix[0].Length;
        bool isCol = false;
        bool isRow = false;
        for(int c=0;c<n;c++){
            if(matrix[c][0]==0) isCol = true;
        }
        for(int r=0;r<m;r++){
            if(matrix[0][r]==0) isRow = true;
        }
        for(int i=1;i<n;i++){
            for(int j=1;j<m;j++){
                if(matrix[i][j]==0){
                    matrix[i][0]=0;
                    matrix[0][j]=0;
                }
            }
        }

        for(int r=1;r<m;r++){
            if(matrix[0][r]==0) SetZero(matrix,r,true);
        }
        for(int c=1;c<n;c++){
            if(matrix[c][0]==0) SetZero(matrix,c,false);
        }

        if(isRow) SetZero(matrix,0,false);  // setting first row
        if(isCol) SetZero(matrix,0,true);   //setting first column
    }
    public void SetZero(int[][] arr,int x,bool isRow){

        // making column zero
        if(isRow){
            for(int c=0;c<arr.Length;c++){
                arr[c][x]=0;
            }
        }
        // making row zero
        else{
            for(int r=0;r<arr[0].Length;r++){
                arr[x][r] = 0;
            }
        }
    }
}