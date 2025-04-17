export class BaseResponseError {
    errorCode?: string;
    errorMessageUser?: string;
    errorMessageSystem?: string;
    constructor(init?: Partial<BaseResponseError>) {
        Object.assign(this, init);
    }
}

export class BaseResponse<TType> extends BaseResponseError {
    resultCode?: number;
    messages: string[] = [];
    totalPages: number = 0;
    totalRecords: number = 0;
    currentPage: number = 0;
    pageSize: number = 0;
    content?: TType;

    constructor(init?: Partial<BaseResponse<TType>>) {
        super(init);
        if (init) {
            this.resultCode = init.resultCode;
            this.messages = init.messages || [];
            this.totalPages = init.totalPages || 0;
            this.totalRecords = init.totalRecords || 0;
            this.currentPage = init.currentPage || 0;
            this.pageSize = init.pageSize || 0;
            this.content = init.content;
        }
    }
}