export class BaseResponseError {
    ErrorCode?: string;
    ErrorMessageUser?: string;
    ErrorMessageSystem?: string;
    constructor(init?: Partial<BaseResponseError>) {
        Object.assign(this, init);
    }
}

export class BaseResponse<TType> extends BaseResponseError {
    ResultCode?: number;
    Messages: string[] = [];
    TotalPages: number = 0;
    TotalRecords: number = 0;
    CurrentPage: number = 0;
    PageSize: number = 0;
    Content?: TType;

    constructor(init?: Partial<BaseResponse<TType>>) {
        super(init);
        Object.assign(this, init);
    }
}